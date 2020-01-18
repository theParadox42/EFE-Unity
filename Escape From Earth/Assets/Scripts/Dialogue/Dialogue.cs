using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue")]
public class Dialogue : ScriptableObject {

    [TextArea(10,14)] [SerializeField] string dialogueText = "";
    [SerializeField] Dialogue nextDialogue = null;

    public string GetDialogueText(){
        return dialogueText;
    }
    public Dialogue GetNextDialogue(){
        return nextDialogue;
    }
}
