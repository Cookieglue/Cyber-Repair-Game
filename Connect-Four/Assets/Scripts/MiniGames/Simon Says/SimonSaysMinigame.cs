using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimonSaysMinigame : MonoBehaviour
{
    [SerializeField] GameObject[] buttons;
    [SerializeField] GameObject[] lightArray;
    [SerializeField] GameObject[] rowLights;
    [SerializeField] int[] lightOrder;
    [SerializeField] GameObject simonGamePanel;
    [SerializeField] int roundsPerGame = 5;
    [SerializeField] float blinkSpeed = 0.5f;
    int level = 0;
    int buttonsClicked = 0;
    int colorOrderRunCount = 0;
    bool passed = false;
    bool won = false;
    Color32 red = new Color32(255, 39, 0, 255);
    Color32 green = new Color32(4, 204, 0, 255);
    Color32 invisible = new Color32(4, 204, 0, 0);
    Color32 white = new Color32(255, 255, 255, 255);
    public float lightSpeed = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        level = 0;
        buttonsClicked = 0;
        colorOrderRunCount = -1;
        won = false;
        for (int i = 0; i < lightOrder.Length; i++)
        {
            lightOrder[i] = Random.Range(0, 8);
        }
        for (int i = 0; i < rowLights.Length; i++)
        {
            rowLights[i].GetComponent<Image>().color = white;
        }

        level = 1;
        StartCoroutine(ColorOrder());
    }

    public void ButtonClickOrder(int button)
    {
        buttonsClicked++;
        if (button == lightOrder[buttonsClicked-1])
        {
            Debug.Log("pass");
            passed = true;
        }
        else
        {
            Debug.Log("failed");
            won = false;
            passed = false;
            StartCoroutine(ColorBlink(red));
        }
        if (buttonsClicked == level && passed && buttonsClicked != roundsPerGame)
        {
            level++;
            passed = false;
            StartCoroutine(ColorOrder());
        }
        if (buttonsClicked == level && passed && buttonsClicked == roundsPerGame)
        {
            Debug.Log("Failed");
            won = true;
            StartCoroutine(ColorBlink(green));
        }
    }

    public void ClosePanel()
    {
        simonGamePanel.SetActive(false);
    }

    public void OpenPanel()
    {
        simonGamePanel.SetActive(true);
    }

    IEnumerator ColorBlink(Color32 blinkColor)
    {
        DisableInteractableButtons();
        for (int x = 0; x < 3; x++)
        {
            Debug.Log("I ran " + x + "times.");
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].GetComponent<Image>().color = blinkColor;
            }
            for (int i = 5; i < rowLights.Length; i++)
            {
                rowLights[i].GetComponent<Image>().color = blinkColor;
            }
            yield return new WaitForSeconds(blinkSpeed);
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].GetComponent<Image>().color = white;
            }
            for (int i = 5; i < rowLights.Length; i++)
            {
                rowLights[i].GetComponent<Image>().color = white;
            }
            yield return new WaitForSeconds(blinkSpeed);
        }
        if (won)
        {
            Debug.Log("Add winning stuff here");
            ClosePanel();
        }
        EnableInteractableButtons();
        OnEnable();
    }

    IEnumerator ColorOrder()
    {
        buttonsClicked = 0;
        colorOrderRunCount++;
        DisableInteractableButtons();
        for (int i = 0; i <= colorOrderRunCount; i++)
        {
            if (level >= colorOrderRunCount)
            {
                lightArray[lightOrder[i]].GetComponent<Image>().color = invisible;
                yield return new WaitForSeconds(lightSpeed);
                lightArray[lightOrder[i]].GetComponent<Image>().color = green;
                yield return new WaitForSeconds(lightSpeed);
                lightArray[lightOrder[i]].GetComponent<Image>().color = invisible;
                rowLights[i].GetComponent<Image>().color = green;
            }
        }
        EnableInteractableButtons();
    }

    void DisableInteractableButtons()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].GetComponent<Button>().interactable = false;
        }
    }

    void EnableInteractableButtons()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].GetComponent<Button>().interactable = true;
        }
    }
}
