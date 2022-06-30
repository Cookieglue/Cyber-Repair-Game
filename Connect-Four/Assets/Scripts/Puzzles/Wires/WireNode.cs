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

        if (wiresController.currentWire == 0 && column == 1) {

            completed = true;
            wiresController.currentWire = order;
            wiresController.currentColumn = column;
            wiresController.UpdateLine(column,order, transform.position);

        }
        else if (wiresController.currentWire == order && wiresController.currentColumn + 1 == column) {

            completed = true;
            wiresController.currentColumn = column;
            wiresController.UpdateLine(column, order, transform.position);
            if (column == 3) {

                //reset wires so you can do another color
                wiresController.currentColumn = 0;
                wiresController.currentWire = 0;

            }

        }
        wiresController.CheckCompletion();

    }
}
