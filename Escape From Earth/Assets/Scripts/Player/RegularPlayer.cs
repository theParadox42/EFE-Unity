using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularPlayer: DialoguePlayer
{

    // Movement Variables
    FixedJoystick fixedJoystick;
    float upSensitivity = 0.5f;
    float downSensitivity = 0.4f;
    float horizontalSensitivity = 0.2f;
    bool snapX = false;
    bool snapY = true;

    // Mobile detection
    bool isMobile = (new DetectMobile()).CheckMobile();

    // Start is called before the first frame update
    void Start()
    {
        InitializeTouchControls();
    }


    // Update is called once per frame
    void Update()
    {
        UpdateMovementControls();
    }

    void InitializeTouchControls() {
        Debug.Log("Initializing Touch Controls");
        try {
            fixedJoystick = FindObjectOfType<FixedJoystick>();
        } catch {
            isMobile = false;
        }
    }
    void UpdateMovementControls() {

        // Movement variables
        float horizontalMovement = 0f;
        float verticalMovement = 0f;

        // Mobile controls
        if(isMobile) {
            horizontalMovement += fixedJoystick.Horizontal;
            verticalMovement += fixedJoystick.Vertical;
        }

        // Keyboard/Gamecontroller Controls
        horizontalMovement += Input.GetAxis("Horizontal");
        verticalMovement += Input.GetAxis("Vertical");

        // Constraints
        horizontalMovement = Mathf.Clamp(horizontalMovement, -1f, 1f);
        verticalMovement = Mathf.Clamp(verticalMovement, -1f, 1f);

        // Options (Sensitivity, Rounding)
        
        // Horizontal
        if(Mathf.Abs(horizontalMovement) > horizontalSensitivity) {
            if(snapX) {
                if(horizontalMovement > 0f) horizontalMovement = 1f;
                if(horizontalMovement < 0f) horizontalMovement = -1f;
            }
            MoveHorizontally(horizontalMovement);
        }

        // Vertical
        if(verticalMovement > upSensitivity) {
            if(snapY) MoveUp(1f);
            else MoveUp(verticalMovement);
        } else if(verticalMovement < downSensitivity) {
            if(snapY) MoveDown(1f);
            else MoveDown(verticalMovement);
        }
    }

    // Move methods
    void MoveUp(float howMuch) {
        Debug.Log("No method implemented for MoveUp");
    }

    void MoveDown(float howMuch) {
        Debug.Log("No method implemented for MoveDown");
    }

    void MoveHorizontally(float howMuch) {
        Debug.Log("No method implemented for MoveHorizontally");
    }

    // Dialogue reciever
    public override void DialogueEnded(DialogueManager dialogueManager)
    {
        Debug.LogWarning("No Response Created For Player", gameObject);
    }


}
