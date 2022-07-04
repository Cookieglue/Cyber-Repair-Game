using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PipeGameManager : MonoBehaviour
{
    public int gameSize = 5;

    [SerializeField] private GameObject node;
    [SerializeField] private Camera cam;
    [SerializeField] private GameObject canvas;

    //straight, left, right
    [SerializeField] private Sprite[] images;
    private string[][] rotations = {
        new string[]{"pipe" , "air", "pipe", "air"},
        new string[]{"air", "air", "pipe", "pipe"},
        new string[]{"air", "pipe", "pipe", "air"},
    };
    void Start()
    {

        for (int x = 0; x < gameSize; x++) {

            for (int y = gameSize; y > 0; y--) {

                //spawn in
                Vector2 nodePos = new Vector2(Screen.height/(gameSize) * x + Screen.width/2 - Screen.height/2, Screen.height/(gameSize) * y) ;
                GameObject nodeGameobject = Instantiate(node, Vector3.zero, Quaternion.identity) as GameObject;

                //transform initialization
                nodeGameobject.transform.SetParent(canvas.transform);
                nodeGameobject.transform.position = nodePos;
                int nodeSize = Screen.height / gameSize;
                nodeGameobject.GetComponent<RectTransform>().sizeDelta = new Vector2(nodeSize, nodeSize );
                nodeGameobject.transform.Translate(new Vector2(nodeSize/2,-nodeSize/2));

                //rotation initialization
                int rand = Random.Range(0, 2);
                nodeGameobject.GetComponent<PipeNode>().sides = rotations[rand];
                nodeGameobject.GetComponent<Image>().sprite = images[rand];

            }

        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
