using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeNode : MonoBehaviour
{
    //up, right, down, left
    public string[] sides = {"superpos", "superpos", "superpos", "superpos" };
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void RotateOnClick() {

        string temp = sides[sides.Length];
        for (int i = sides.Length; i > 0; i--) {

            sides[i] = sides[i - 1];

        }
        sides[0] = temp;

    }

    void RotateRandom() {

        int rand = Random.Range(0,3);

        string[] tempList = new string[4];

        for(int i = 0; i < sides.Length; i ++) {

            tempList[i] = sides[i];
        
        }

        for (int i = 0; i < sides.Length; i++)
        {

            sides[i] = tempList[ (i + rand) % 4];

        }


    }

}
