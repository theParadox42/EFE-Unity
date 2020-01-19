using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum WakeUpPlayerState {
    sleeping,
    gettingOutOfBed,
    dialogue,
    leaving,
    finished
}

public class BreakingNewsPlayer: DialogueDelegate
{
    
    // State Management
    WakeUpPlayerState state = WakeUpPlayerState.sleeping;
    
    // Animation Stuff
    Animator animator;

    // Dialouge Manager
    DialogueManager dialogueManager;

    // Scene Loader
    [SerializeField] SceneLoader sceneLoader = null;
    
    void Start() {
        animator = GetComponent<Animator>();
        dialogueManager = GetComponent<DialogueManager>();
    }

    public void StartScene() {
        animator.SetTrigger("GetOutOfBed");
        state = WakeUpPlayerState.gettingOutOfBed;
    }

    void Update() {
        var animationState = animator.GetCurrentAnimatorStateInfo(0);
        switch(state) {
            case WakeUpPlayerState.gettingOutOfBed:
                if(animationState.IsName("GetOutOfBed")) {
                    state = WakeUpPlayerState.dialogue;
                    dialogueManager.StartDialogue();
                }
            break;
            case WakeUpPlayerState.leaving:
                if(animationState.IsName("LeaveRight")) {
                    state = WakeUpPlayerState.finished;
                    sceneLoader.LoadNextScene();
                }
            break;
        }
    }

    public override void DialogueEnded(DialogueManager dialogueManager)
    {
        state = WakeUpPlayerState.leaving;
        animator.ResetTrigger("GetOutOfBed");
        animator.SetTrigger("LeaveRight");
    }

}
