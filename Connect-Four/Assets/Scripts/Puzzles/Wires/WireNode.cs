using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WireNode : MonoBehaviour
{
    public bool completed = false;

    public int order;

    public int column;

    private ButtonGeneration wiresController;


    private void Start()
    {
        // has to go up 3 times in heirarchy (kinda gross code lol)
        wiresController = transform.parent.transform.parent.transform.parent.GetComponent<ButtonGeneration>();

        Button btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener(CheckWires);
    }
    void CheckWires() {

        if (wiresController.currentWire == 0) {

            wiresController.currentWire = order;

        }
        else if (wiresController.currentWire == order && column == wiresController.currentColumn+1) {

            completed = true;
            if (column == 3) {

                //reset wires so you can do another color
                wiresController.currentColumn = 0;
                wiresController.currentWire = 0;

            }

        }

    }
}
