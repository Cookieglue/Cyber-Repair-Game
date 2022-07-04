using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PipeGameManager : MonoBehaviour
{
    public static int gameSize = 5;

    [SerializeField] private GameObject node;
    [SerializeField] private Camera cam;
    [SerializeField] private GameObject canvas;

    //straight, left, right
    [SerializeField] private Sprite[] images;
    private string[][] types = {
        new string[]{"pipe" , "air", "pipe", "air"},
        new string[]{"air", "air", "pipe", "pipe"},
        new string[]{"air", "pipe", "pipe", "air"},
    };

    private GameObject[,] nodeRefrences = new GameObject[gameSize, gameSize];

    private Dictionary<int, int[]> moveIndex;
    private int[] generationPos = new int[2];

    void Start()
    {
        moveIndex.Add(0, new int[] { 0, 1 });
        moveIndex.Add(1, new int[] { 1, 0 });
        moveIndex.Add(2, new int[] { 0, -1 });
        moveIndex.Add(3, new int[] { -1, 0 });

        for (int x = 0; x < gameSize; x++) {

            for (int y = 0; y < gameSize; y++) {

                //spawn in
                Vector2 nodePos = new Vector2(Screen.height / (gameSize) * x + Screen.width / 2 - Screen.height / 2, Screen.height / (gameSize) * (y+1));
                GameObject nodeGameobject = Instantiate(node, Vector3.zero, Quaternion.identity) as GameObject;

                //transform initialization
                nodeGameobject.transform.SetParent(canvas.transform);
                nodeGameobject.transform.position = nodePos;
                int nodeSize = Screen.height / gameSize;
                nodeGameobject.GetComponent<RectTransform>().sizeDelta = new Vector2(nodeSize, nodeSize);
                nodeGameobject.transform.Translate(new Vector2(nodeSize / 2, -nodeSize / 2));

                //straight or turn pipe initialization

                /**
                int rand = Random.Range(0, 2);
                nodeGameobject.GetComponent<PipeNode>().sides = types[rand];
                nodeGameobject.GetComponent<Image>().sprite = images[rand];
                nodeGameobject.GetComponent<PipeNode>().RotateAmount(Random.Range(0, 3));
                **/

                nodeRefrences[x, y] = nodeGameobject;

                //print(nodeRefrences[x, y].transform.name);

            }

        }
        GeneratePath();

    }

    void GeneratePath(){

        int[] startPos = { 0, Random.Range(0, gameSize-1) };
        int[] endPos = { gameSize-1, Random.Range(0, gameSize-1) };

        SetPipetype(nodeRefrences[startPos[0], startPos[1]], 0, 1);
        SetPipetype(nodeRefrences[endPos[0], endPos[1]], 0, 1);

        generationPos = startPos;
        IteratePath();

    }
    void IteratePath()
    {

        for (int rot = 0; rot < 4; rot++)
        {

            if ((nodeRefrences[generationPos[0], generationPos[1]]).GetComponent<PipeNode>().sides[rot] == "pipe")
            {

                int[] translation = moveIndex[rot];
                generationPos[0] += translation[0];
                generationPos[1] += translation[1];
                print(generationPos);
                SetPipetype(nodeRefrences[generationPos[0], generationPos[1]], 0, 1);
                IteratePath();

            }

        }

    }

    void SetPipetype(GameObject node, int type, int rot) {

        PipeNode pipeNode = node.GetComponent<PipeNode>();
        pipeNode.sides = types[type];
        node.GetComponent<Image>().sprite = images[type];
        pipeNode.RotateAmount(rot);

    }

}
