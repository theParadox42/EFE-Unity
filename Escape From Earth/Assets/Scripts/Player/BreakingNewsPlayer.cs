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
    

    void Start() {
        animator = GetComponent<Animator>();
    }

    public void StartScene() {
        animator.SetTrigger("GetOutOfBed");
        state = WakeUpPlayerState.gettingOutOfBed;
    }

    void Update() {
        switch(state) {
            case WakeUpPlayerState.gettingOutOfBed:
                if(animator.GetCurrentAnimatorStateInfo(0).IsName("GetOutOfBed")) {
                    Debug.Log("Currently get out of bed");
                } else {
                    // // Set position
                    // var pos = transform.position;
                    // transform.position = new Vector2(pos.x, -2.2f, pos.z);
                    // // Set rotation
                    // var rot = transform.rotation;
                    // transform.rotation = new Vector3(rot.x, rot.y, 180);
                    // // log
                    // Debug.Log("Ok it worked");
                    // TODO: Set transform to right position
                }
            break;
        }
    }

    public override void DialogueEnded(DialogueManager dialogueManager)
    {
        
    }


}
