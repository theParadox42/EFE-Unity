using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueDelegate : MonoBehaviour
{
    
    public virtual void DialogueEnded(DialogueManager dialogueManager)
    {
        Debug.LogWarning("No Response Created");
        Debug.Log("DialogueManager Unused: ", dialogueManager);
    }

}
