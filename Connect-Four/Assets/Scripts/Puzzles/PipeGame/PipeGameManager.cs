using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeGameManager : MonoBehaviour
{
    public int gameSize = 5;

    [SerializeField] private GameObject node;
    [SerializeField] private Camera cam;
    void Start()
    {

        for (int x = 0; x < gameSize; x++) {

            for (int y = 0; y < gameSize; y++) {

                Vector2 nodePos = cam.ScreenToWorldPoint( new Vector3(x * Screen.width/gameSize,y * Screen.height / gameSize) );
                Instantiate(node, nodePos, Quaternion.identity);

            }

        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
