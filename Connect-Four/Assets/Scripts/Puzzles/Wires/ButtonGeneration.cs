using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;


public class ButtonGeneration : MonoBehaviour
{
    [SerializeField] private GameObject[] start;
    [SerializeField] private GameObject[] medium;
    [SerializeField] private GameObject[] end;

    [SerializeField] private Color[] colors= new Color[]{Color.red, Color.green, Color.blue};

    public int currentWire;


    void Start()
    {

        List<GameObject>[] conglomerate = new List<GameObject>[] { start.ToList(), medium.ToList(), end.ToList() };

        for (int i = 0; i <= conglomerate.Length; i ++) {

            int colorNum = 0;

            while(conglomerate[i].Count > 0) {

                int index = Random.Range(0, conglomerate[i].Count);
                conglomerate[i][index].GetComponent<Image>().color = colors[colorNum];
                conglomerate[i][index].GetComponent<WireNode>().order = colorNum + 1;
                conglomerate[i].RemoveAt(index);
                colorNum++;

            }

        }
    }
    public void CheckCompletion()
    {

        foreach (GameObject gameObject in start) {

            if (gameObject.GetComponent<WireNode>().completed == false) return;

        }
        foreach (GameObject gameObject in medium)
        {

            if (gameObject.GetComponent<WireNode>().completed == false) return;

        }
        foreach (GameObject gameObject in end)
        {

            if (gameObject.GetComponent<WireNode>().completed == false) return;

        }

        print("All done!");

    }
}
