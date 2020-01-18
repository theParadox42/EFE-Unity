using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakingNewsManager : GameManager
{

    BreakingNewsPlayer player = null;

    private void Start() {
        player = GameObject.FindObjectOfType<BreakingNewsPlayer>();
    }

    public override void DialogueEnded(DialogueManager dialogueManager)
    {
        player.StartScene();
    }
    

}
