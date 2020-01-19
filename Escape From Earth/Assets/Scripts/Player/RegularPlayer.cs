using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularPlayer: DialoguePlayer
{

    // Movement Variables
    FixedJoystick fixedJoystick;
    float jumpSensitivity = 0.5f;
    float duckSensitivity = 0.4f;
    float moveSensitivity = 0.2f;
    bool roundX = false;
    bool roundY = true;

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
        
    }

    void InitializeTouchControls() {
        Debug.Log("Initializing Touch Controls");
        if(isMobile) {

        }
    }
    void UpdateControls() {
        float horizantalMovement = 0f;
        float verticalMovement = 0f;
        if(isMobile) {
            
        }
    }

    // Move methods
    void MoveUp(float howMuch) {
        Debug.Log("No method implemented for MoveUp");
    }

    void MoveDown(float howMuch) {
        Debug.Log("No method implemented for MoveDown");
    }

    void MoveRight(float howMuch) {
        Debug.Log("No method implemented for MoveRight");
    }
    void MoveLeft(float howMuch) {
        Debug.Log("No method implemented for MoveLeft");
    }

    // Dialogue reciever
    public override void DialogueEnded(DialogueManager dialogueManager)
    {
        Debug.LogWarning("No Response Created For Player", gameObject);
    }


}
