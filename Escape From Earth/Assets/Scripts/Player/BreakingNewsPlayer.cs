using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum WakeUpPlayerState {
    sleeping,
    gettingOutOfBed,
    dialogue,
    leaving
}

public class BreakingNewsPlayer : DialogueDelegate
{
    
    // State Management
    WakeUpPlayerState state = WakeUpPlayerState.sleeping;
    
    // Animation Stuff
    Animator animator;

    // DialougeManager
    DialogueManager dialogueManager;
    

    void Start() {
        animator = GetComponent<Animator>();
        dialogueManager = GetComponent<DialogueManager>();
    }

    public void StartScene() {
        animator.SetTrigger("GetOutOfBed");
        state = WakeUpPlayerState.gettingOutOfBed;
    }

    void Update() {
        switch(state) {
            case WakeUpPlayerState.gettingOutOfBed:
                var animationState = animator.GetCurrentAnimatorStateInfo(0);
                if(animationState.IsName("GetOutOfBed")) {
                    state = WakeUpPlayerState.dialogue;
                    dialogueManager.StartDialogue();
                }
            break;
        }
    }

    public override void DialogueEnded(DialogueManager dialogueManager)
    {
        
    }


}
