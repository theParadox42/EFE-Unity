using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{

    // Dialogue Management Objects
    [SerializeField] Dialogue firstDialogue = null;
    Dialogue currentDialogue;
    
    // Delegate Methods
    [SerializeField] DialogueDelegate dialogueDelegate = null;
    bool sentSignal = false;

    // TMP Component
    [SerializeField] TextMeshPro storyText = null;

    // Management Settings
    [SerializeField] float charactersPerSecond = 0.1f;
    [SerializeField] bool automaticallyStart = true;
    bool on = true;
    
    // Text Stuff
    string currentText = "";
    string displayText = "";
    int textIndex = 0;
    bool spittingDialogue = true;


    public void StartDialogue() {
        InitializeDialogue();
    }

    // Start is called before the first frame update
    void Start()
    {   
        if(automaticallyStart) InitializeDialogue();
        else 
        {
            displayText = "";
            UpdateUI();
            on = false;
        }
    }

    void InitializeDialogue(){
        if (firstDialogue != null) SetDialogue(firstDialogue);
        else
        {
            DialogueFinished();
            Debug.LogWarning("No Dialogue was inputed, here is null object.", firstDialogue);
        }
    }

    void Update()
    {
        if (on) {
            UpdateUI();
            HandleInput();
        }
    }

    void SetDialogue(Dialogue dialogueToSet)
    {
        on = true;
        currentDialogue = dialogueToSet;
        currentText = currentDialogue.GetDialogueText();
        displayText = "";
        textIndex = 0;
        spittingDialogue = true;
        InvokeRepeating("UpdateTextLength", 0f, charactersPerSecond);
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
        } else {
            spittingDialogue = false;
            CancelInvoke();
        }
    }

    void HandleInput() {
        if(Input.GetMouseButtonUp(0) || Input.GetKeyUp("space")) {
            if(spittingDialogue) {
                spittingDialogue = false;
                CancelInvoke();
                displayText = currentText;
            } else {
                NextText();
            }
        }
    }

    void NextText()
    {
        if (currentDialogue.GetNextDialogue() != null)
        {
            SetDialogue(currentDialogue.GetNextDialogue());
        }
        else
        {
            DialogueFinished();
        }
    }

    void DialogueFinished() {
        on = false;
        displayText = "";
        UpdateUI();
        if(dialogueDelegate != null && !sentSignal) {
            sentSignal = true;
            dialogueDelegate.DialogueEnded(this);
        }
    }


}
