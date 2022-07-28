using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopCameraControl : MonoBehaviour
{
    public Transform[] RoomPositions;
    [SerializeField] private float[] minMax;
    [SerializeField] private Button[] navButtons = new Button[2]; // Navigation button Array given to the script in the editor. Moves the char left or right.
    [SerializeField] private float scrollSpeed =20;
    [SerializeField] private float scrollBuffer = 0.25f; // Buffer around the edges of the screen from 0-1 as a fraction of the screen.
    [SerializeField] private int currentRoom = 0; //Current room 0 being the shop, 1 being the Operating Room, and 2 being the back room potentialy.
    [SerializeField] private float moveTime = 5; // The time it takes to move from one room to another upon button click.
    private float scrollX;

    void Start()
    {
        for(int i = 0; i < navButtons.Length; i++)
        {
            int closureIndex = i;
            navButtons[closureIndex].onClick.AddListener(   () => MoveByButtons(closureIndex)  );
        }
    }

    void Update()
    {
        
    }

    private void MoveByMouse()
    {
        // If mouse is within left screen buffer move left by scroll speed * delta
        if (Input.mousePosition.x / Screen.width < scrollBuffer && scrollX >= minMax[0])
        {

            scrollX -= scrollSpeed * Time.deltaTime;
            print(Input.mousePosition + " " + scrollX); // DEBUG

        }
        // If mouse is within right screen buffer move left by scroll speed * delta
        if (Input.mousePosition.x / Screen.width > 1 - scrollBuffer && scrollX <= minMax[1])
        {

            scrollX += scrollSpeed * Time.deltaTime;
            print(Input.mousePosition + " " + scrollX); // DEBUG

        }
        this.transform.position = new Vector3(Mathf.Clamp(scrollX, minMax[0], minMax[1]), 0, -10);
    }

    private void MoveByButtons(int buttonIndex)
    {
        if(buttonIndex == 0)
        {
            switch (currentRoom)
            {
                case 0:
                    currentRoom = 2;
                    StartCoroutine(LerpPosition(RoomPositions[2].position, moveTime));
                    break;
                case 1:
                    currentRoom = 0;
                    StartCoroutine(LerpPosition(RoomPositions[0].position, moveTime));
                    break;
                case 2:
                    print("oof");
                    break;
            }
        }
        else if (buttonIndex == 1)
        {
            switch (currentRoom)
            {
                case 0:
                    currentRoom = 1;
                    StartCoroutine(LerpPosition(RoomPositions[1].position, moveTime));
                    break;
                case 1:
                    print("oof");
                    break;
                case 2:
                    currentRoom = 0;
                    StartCoroutine(LerpPosition(RoomPositions[0].position, moveTime));
                    break;
            }
        }
        //Add here
    }

    IEnumerator LerpPosition(Vector3 endPosition, float duration)
    {
        float time = 0;
        Vector3 startPosition = transform.position;
        while(time < duration)
        {
            this.transform.position = Vector3.Lerp(startPosition, endPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        transform.position = endPosition;
    }
}
