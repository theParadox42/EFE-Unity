using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueDelegate : MonoBehaviour
{
    
    delegate void DialogueEnded(DialogueManager dialogueManager);

    public virtual void DialogueEnded(DialogueManager dialogueManager)
    {
        Debug.LogWarning("No Response Created", dialogueManager);
    }

}
