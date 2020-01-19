using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager: DialogueDelegate
{

    // Just a general class for game managers to build off of

    public virtual void DialogueEnded(DialogueManager dialogueManager)
    {
        Debug.LogWarning("Dialogue ended from");
        Debug.Log("Dialogue object unused");
    }

}
