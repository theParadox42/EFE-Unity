using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularPlayer: DetectMobile
{

    FixedJoystick fixedJoystick;
    float jumpSensitivity = 0.5f;
    float duckSensitivity = 0.4f;
    float moveSensitivity = 0.2f;
    bool roundX = false;
    bool roundY = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    void InitializeTouchControls() {
        if(CheckMobile()) {

        }
    }
    void UpdateControls() {
        float horizantalMovement = 0f;
        float verticalMovement = 0f;
        if(CheckMobile()) {
            
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
    public void DialogueEnded(DialogueManager dialogueManager)
    {
        Debug.LogWarning("No Response Created For Player", gameObject);
    }


}
