using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialoguePlayer: DialogueDelegate
{
    
    public override void DialogueEnded(DialogueManager dialogueManager)
    {
        Debug.Log("Player has no response", gameObject);
    }

}
