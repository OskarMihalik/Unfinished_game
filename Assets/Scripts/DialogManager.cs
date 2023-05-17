using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Ink.Runtime;

public class DialogManager : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;

    public float typingSpeed;
    public GameObject continueButton;
    public GameManager gameManager;
    private int index;


    public TextAsset inkFile;
    public Story story;

    public void StartConversation()
    {
        gameObject.SetActive(true);
        story = new Story(inkFile.text);
        NextSentence();
        gameManager.StopPlayer();
    }
    
    IEnumerator Type(string sentence)
    {
        textDisplay.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        continueButton.SetActive(true);
    }

    public void NextSentence()
    {
        continueButton.SetActive(false);
        if (story.canContinue)
        {
            AdvanceDialog();
        }
        else
        {
            textDisplay.text = "";
            gameObject.SetActive(false);
            gameManager.ResumePlayer();
        }

    }

    private void AdvanceDialog()
    {
        string currentSentence = story.Continue();
        StartCoroutine(Type(currentSentence));
    }
}
