using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class RegularPlayer: DialoguePlayer
{

    // Components/Objects
    protected FixedJoystick fixedJoystick;
    protected Rigidbody2D rb;
    protected Collider2D myCollider;

    #region Movement Config Variables

    // Sensitivities
    protected float upSensitivity = 0.5f;
    protected float downSensitivity = 0.4f;
    protected float horizontalSensitivity = 0.2f;
    // Snappy
    protected bool snapX = false;
    protected bool snapY = true;
    // Mobile Control Variables
    protected bool hasMobileControl = false;
    protected bool isMobile = false;
    DetectMobile detector = new DetectMobile();
    // Ground Stuff
    public bool grounded = false;
    protected bool requiresGroundedToJump = true;
    // For checking groundedness
    LayerMask groundLayers;

    #endregion

    // Start is called before the first frame update
    protected void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<Collider2D>();
        groundLayers = LayerMask.GetMask("GroundLayers");
        InitializeTouchControls();
    }

    // Update is called once per frame
    protected void Update()
    {
        UpdateMovementControls();
        UpdateGrounded();
    }

    // Update if grounded
    void UpdateGrounded() {
        Vector2 extents = myCollider.bounds.extents;
        Vector2 center = myCollider.bounds.center;
        grounded = Physics2D.OverlapArea(
            new Vector2(center.x + extents.x, center.y - extents.y),
            new Vector2(center.x - extents.x, center.y - extents.y + 0.1f),
            groundLayers);
    }
    
    // Movement controls, as the line below suggests.
    #region Movement Controls

    // Init/Start and Update control methods
    void InitializeTouchControls() {
        try {
            fixedJoystick = FindObjectOfType<FixedJoystick>();
        } catch {
            // Nothing happens here
        }
        hasMobileControl = fixedJoystick == null ? false : true;
    }
    void UpdateMovementControls() {

        // Movement variables
        float horizontalMovement = 0f;
        float verticalMovement = 0f;

        // Mobile controls
        if(hasMobileControl) {
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
            if(!requiresGroundedToJump || (requiresGroundedToJump && grounded)) {
                if (snapY) MoveUp(1f);
                else MoveUp(verticalMovement);
            }
        } else if(verticalMovement < -downSensitivity) {
            if(snapY) MoveDown(1f);
            else MoveDown(verticalMovement);
        }

        // Mobile Boolean
        isMobile = detector.CheckMobile();
    }

    // Move methods
    protected virtual void MoveUp(float howMuch) {
        Debug.Log("No method implemented for MoveUp");
    }

    protected virtual void MoveDown(float howMuch) {
        Debug.Log("No method implemented for MoveDown");
    }

    protected virtual void MoveHorizontally(float howMuch) {
        Debug.Log("No method implemented for MoveHorizontally");
    }

    // Dialogue reciever
    public override void DialogueEnded(DialogueManager dialogueManager)
    {
        Debug.LogWarning("No Response Created For RegularPlayer", gameObject);
    }
    #endregion

}
