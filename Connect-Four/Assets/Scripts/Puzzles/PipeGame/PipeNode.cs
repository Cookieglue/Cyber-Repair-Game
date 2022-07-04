using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PipeNode : MonoBehaviour
{
    //up, right, down, left
    public string[] sides = {"superpos", "superpos", "superpos", "superpos" };
    void Start()
    {
        Button btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener(RotateOnClick);
    }

    void RotateOnClick() {

        transform.Rotate(new Vector3(0,0,90));

        string[] tempList = new string[4];

        for (int i = 0; i < sides.Length; i++)
        {

            tempList[i] = sides[i];

        }

        for (int i = 0; i < sides.Length; i++)
        {

            sides[i] = tempList[(i + 1) % 4];

        }

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
