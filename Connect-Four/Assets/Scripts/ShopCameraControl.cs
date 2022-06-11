using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopCameraControl : MonoBehaviour
{
    [SerializeField] private int[] minMax = {0,22};
    [SerializeField] private float scrollSpeed =20;
    [SerializeField] private float scrollBuffer = 0.25f; // Buffer around the edges of the screen from 0-1 as a fraction of the screen.
    private float scrollX;

    void Start()
    {
    }

    void Update()
    {
        if (Input.mousePosition.x / Screen.width < scrollBuffer) {

            scrollX -= scrollSpeed* Time.deltaTime;

        }
        else if (Input.mousePosition.x / Screen.width > 1 - scrollBuffer)
        {

            scrollX += scrollSpeed * Time.deltaTime;

        }
        transform.position = new Vector3(Mathf.Clamp(scrollX, minMax[0], minMax[1]), 0, -10);
    }
}
