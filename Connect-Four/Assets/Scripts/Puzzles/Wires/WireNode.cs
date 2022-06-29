using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WireNode : MonoBehaviour
{
    public bool completed = false;

    public int order;

    private ButtonGeneration wiresController;

    private void Start()
    {
        // has to go up 3 times in heirarchy (kinda gross code lol)
        wiresController = transform.parent.transform.parent.transform.parent.GetComponent<ButtonGeneration>();
    }
    void StartWire() {

        if (wiresController.currentWire == 0) {

            wiresController.currentWire = order;

        }
        else if (wiresController.currentWire == order) {
        
        }
        else if (wiresController.currentWire != order)
        {

        }

    }
}
