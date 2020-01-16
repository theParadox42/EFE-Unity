using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{

    // Dialogue Management Objects
    [SerializeField] Dialogue firstDialogue;
    Dialogue currentDialogue;

    // TMP Component
    [SerializeField] TextMeshPro storyText;

    // Text Stuff
    [SerializeField] float charactersPerSecond = 0.1f;
    string currentText = "";
    string displayText = "";
    int textIndex = 0;


    // Start is called before the first frame update
    void Start()
    {
        if (firstDialogue != null)
        {
            currentDialogue = firstDialogue;
            UpdateUI();
            InvokeRepeating("UpdateTextLength", 0f, charactersPerSecond);
        }
    }

    void Update()
    {
        UpdateUI();

    }

    void UpdateUI()
    {
        storyText.text = displayText;
    }

    void UpdateTextLength()
    {
        if(textIndex < currentText.Length) {
            displayText += currentText[textIndex];
            textIndex ++;
        }
    }

    void SetDialogue(Dialogue dialogueToSet) {
        currentDialogue = dialogueToSet;
        currentText = currentDialogue.GetDialogueText();
        displayText = "";
        textIndex = 0;
    }

    void NextText()
    {
        Dialogue newDialogue = currentDialogue.GetNextDialogue();
        if (newDialogue != null)
        {
            SetDialogue(newDialogue);
        }
        else
        {

        }
    }

}
