using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;


public class ButtonGeneration : MonoBehaviour
{
    [SerializeField] private LineRenderer[] lines;

    [SerializeField] private GameObject[] start;
    [SerializeField] private GameObject[] medium;
    [SerializeField] private GameObject[] end;

    [SerializeField] private Color[] colors= new Color[]{Color.red, Color.green, Color.blue};

    public int currentWire;
    public int currentColumn = 0;

    [SerializeField] private Camera camera;

    void Start()
    {

        List<GameObject>[] conglomerate = new List<GameObject>[] { start.ToList(), medium.ToList(), end.ToList() };

        for (int i = 0; i <= conglomerate.Length; i ++) {

            lines[i].positionCount = 3;
            int colorNum = 0;

            while(conglomerate[i].Count > 0) {

                int index = Random.Range(0, conglomerate[i].Count);
                conglomerate[i][index].GetComponent<Image>().color = colors[colorNum];
                conglomerate[i][index].GetComponent<WireNode>().order = colorNum + 1;
                conglomerate[i][index].GetComponent<WireNode>().column = i + 1;
                conglomerate[i].RemoveAt(index);
                colorNum++;

            }

        }
    }
    public void UpdateLine(int column, int wireColor, Vector3 position) {

        print(wireColor - 1);
        print(column - 1);
        Vector3 linePos = camera.ScreenToWorldPoint(position);
        linePos = new Vector3(linePos.x, linePos.y, -0.1f);
        lines[wireColor - 1].SetPosition(column - 1, linePos);

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
