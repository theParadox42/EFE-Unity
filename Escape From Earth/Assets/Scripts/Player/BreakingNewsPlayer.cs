using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum WakeUpPlayerState {
    sleeping,
    gettingOutOfBed,
    dialogue,
    leaving
}

public class BreakingNewsPlayer : MonoBehaviour
{
    
    // State Management
    WakeUpPlayerState state = WakeUpPlayerState.sleeping;

    

    // Update is called once per frame
    void Update()
    {

    }
}
