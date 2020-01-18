using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakingNewsManager : GameManager
{

    public override void DialogueEnded(DialogueManager dialogueManager)
    {
        Debug.Log("Successfully recieved end signal.", dialogueManager);
    }
    

}
