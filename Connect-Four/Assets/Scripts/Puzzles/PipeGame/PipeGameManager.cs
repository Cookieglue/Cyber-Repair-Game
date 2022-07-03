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
    void Start()
    {

        for (int x = 0; x < gameSize; x++) {

            for (int y = gameSize; y > 0; y--) {

                Vector2 nodePos = new Vector2(Screen.height/(gameSize) * x + Screen.width/2 - Screen.height/2, Screen.height/(gameSize) * y) ;
                GameObject nodeGameobject = Instantiate(node, Vector3.zero, Quaternion.identity) as GameObject;
                nodeGameobject.transform.SetParent(canvas.transform);
                nodeGameobject.transform.position = nodePos;

            }

        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
