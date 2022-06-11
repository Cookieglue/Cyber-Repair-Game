using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimonSays : MonoBehaviour
{
    // init vars
    [SerializeField] private int rows;
    [SerializeField] private int columns;
    [SerializeField] private GameObject gameButtonPrefab;
    [SerializeField] private List<ButtonSettings> buttonSettings;
    [SerializeField] int numberOfButtons = 9;
    [SerializeField] int buttonRows = 3;
    [SerializeField] int buttonColumns = 3;
    [SerializeField] Transform gameFieldTransform;

    private List<GameObject> gameButtons;
    private List<int> stages;
    private int currentStages;
    private List<int> userStages;
    private System.Random randGen;
    bool input = false;
    bool end = false;

    // Start is called before the first frame update
    void Start()
    {
        gameButtons = new List<GameObject>();
        CreateButton()
    }

    private void CreateButton(int i, Vector3 pos)
    {
        GameObject button = Instantiate(gameButtonPrefab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;

        button.transform.SetParent(gameFieldTransform);
        button.transform.localPosition = pos;

        button.GetComponent<Image>().color = buttonSettings[i].baseColor;
        button.GetComponent<Button>().onClick.AddListener(() =>
        {
            //add on button click code here
        });

        gameButtons.Add(button);
    }

    private void CreateButtonGrid()
    {
        for (int x = numberOfButtons; x >= 0; x--)
        {
            CreateButton(x, new Vector3(gameButtonPrefab.GetComponent<Image>().GetComponent<RectTransform>().rect.width,))
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
