using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunToRocketPlayer : RegularPlayer
{

    bool crouching = false;

    Animator myAnimator;

    // Start is called before the first frame update
    new void Start()
    {
        // Call the base class Start Method
        base.Start();
        // Do Additional Config Here
        horizontalSensitivity = 0f;
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    new void Update()
    {
        // Base Class update
        crouching = false;
        base.Update();

        UpdateAnimator();
    }

    void UpdateAnimator() {
        myAnimator.SetBool("grounded", grounded);
        myAnimator.SetFloat("speed", Mathf.Abs(rb.velocity.x));
        myAnimator.SetBool("crouching", crouching);
    }

    protected override void MoveUp(float howMuch) {
        rb.velocity = new Vector2(rb.velocity.x, 10f);
    }

    protected override void MoveDown(float howMuch) {
        crouching = grounded;
    }

    protected override void MoveHorizontally(float howMuch){ 
        rb.velocity = new Vector2(howMuch * 5f, rb.velocity.y);
    }

}
