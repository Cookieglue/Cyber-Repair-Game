using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimonSays : MonoBehaviour
{
    // init vars
    [SerializeField] private GameObject gameButtonPrefab;
    public List<ButtonSettings> buttonSettings;
    [SerializeField] AudioClip[] buttonBeeps;
    [SerializeField] Transform gameFieldTransform;
    [SerializeField] int stagesInFirstRound = 3;

    private List<GameObject> gameButtons;
    private List<int> stages;
    private List<int> userStages;
    private int numberOfStages;
    private System.Random randGen;
    bool userInput = false;
    bool end = false;

    // Start is called before the first frame update
    void Start()
    {
        numberOfStages = stagesInFirstRound;
        gameButtons = new List<GameObject>();
        CreateButtonGrid();
    }


    private void CreateButton(int i, Vector3 pos)
    {
        //Instantiate a new button instance from assigned gameButtonPrefab named Simon Says Button i+1
        GameObject button = Instantiate(gameButtonPrefab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        button.name = "Simon Says Button " + (i+1);

        // set the instance as a child of the gameFieldTransform and sets local pos to given pos
        button.transform.SetParent(gameFieldTransform);
        button.transform.localPosition = pos;

        //Get the setting from buttonSettings.cs, assigns the text and adds button click func call.
        button.GetComponent<Image>().color = buttonSettings[i].baseColor;
        Color tempColor = button.GetComponent<Image>().color;
        button.GetComponent<Image>().color = new Color(tempColor.r, tempColor.g, tempColor.b, 1); // set the alpha to max opacirty of the assigned colors.
        button.GetComponentInChildren<Text>().text = (i+1).ToString();
        button.GetComponentInChildren<Text>().fontSize = buttonSettings[i].fontSize;
        button.GetComponent<Button>().onClick.AddListener(() =>
        {
            OnGameButtonClick(i);
        });
        
        //ads the instanced button to gameButtons List
        gameButtons.Add(button);
    }

    // creates buttons in a 3x3 grid attached to the assigned gameFieldTransform
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

    void PlayAudio(int beepsIndex)
    {
        //Note I will need to know how many sounds we have to finish this method

        // play audio clip from indexed position of buttonBeeps array at the main cameras audio listener so the user can always hear.
        AudioSource.PlayClipAtPoint(buttonBeeps[beepsIndex], Camera.main.GetComponent<AudioListener>().transform.position);
    }

    void OnGameButtonClick(int i)
    {
        if (!userInput)
        {
            return;
        }
        StartCoroutine(Beep(i));

        userStages.Add(i);

        if (stages[userStages.Count - 1] != i)
        {
            GameOver();
            return;
        }

        if (stages.Count == userStages.Count)
        {
            StartCoroutine(SimonSaysGameplay());
        }
    }

    IEnumerator SimonSaysGameplay()
    {
        userInput = false;

        randGen = new System.Random("SimonSeed".GetHashCode());

        SetStages();

        yield return new WaitForSeconds(1f);

        for (int i = 0; i < stages.Count; i++)
        {
            Beep(stages[i]);

            yield return new WaitForSeconds(0.5f);
        }

        userInput = true;

        yield return null;
    }

    void SetStages()
    {
        stages = new List<int>();
        userStages = new List<int>();

        for (int i = 0; i < numberOfStages; i++)
        {
            stages.Add(randGen.Next(0, gameButtons.Count));
        }
        numberOfStages++;
    }

    IEnumerator Beep(int i)
    {
        gameButtons[i].GetComponentInChildren<Color>().Equals(buttonSettings[i].highlightColor);
        PlayAudio(i);
        yield return new WaitForSeconds(0.25f);
        gameButtons[i].GetComponentInChildren<Color>().Equals(buttonSettings[i].baseColor);
    }

    void GameOver()
    {
        end = true;
        userInput = false;
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
