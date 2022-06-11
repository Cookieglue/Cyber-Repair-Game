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
    public List<ButtonSettings> buttonSettings;
    [SerializeField] AudioClip[] buttonBeeps;
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
        CreateButtonGrid();
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
        CreateButton(0, new Vector3(-gameButtonPrefab.GetComponent<Image>().GetComponent<RectTransform>().rect.width, gameButtonPrefab.GetComponent<Image>().GetComponent<RectTransform>().rect.width, -10));
        CreateButton(1, new Vector3(0, gameButtonPrefab.GetComponent<Image>().GetComponent<RectTransform>().rect.width, -10));
        CreateButton(2, new Vector3(gameButtonPrefab.GetComponent<Image>().GetComponent<RectTransform>().rect.width, gameButtonPrefab.GetComponent<Image>().GetComponent<RectTransform>().rect.width, -10));

        CreateButton(3, new Vector3(-gameButtonPrefab.GetComponent<Image>().GetComponent<RectTransform>().rect.width, 0, -10));
        CreateButton(4, new Vector3(0, 0, -10));
        CreateButton(5, new Vector3(gameButtonPrefab.GetComponent<Image>().GetComponent<RectTransform>().rect.width, 0, -10));

        CreateButton(6, new Vector3(-gameButtonPrefab.GetComponent<Image>().GetComponent<RectTransform>().rect.width, -gameButtonPrefab.GetComponent<Image>().GetComponent<RectTransform>().rect.width, -10));
        CreateButton(7, new Vector3(0, -gameButtonPrefab.GetComponent<Image>().GetComponent<RectTransform>().rect.width, -10));
        CreateButton(8, new Vector3(gameButtonPrefab.GetComponent<Image>().GetComponent<RectTransform>().rect.width, -gameButtonPrefab.GetComponent<Image>().GetComponent<RectTransform>().rect.width, -10));
    }

    void PlayAudio(int i)
    {
        AudioSource.PlayClipAtPoint(buttonBeeps[i], Camera.main.transform.position);
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
