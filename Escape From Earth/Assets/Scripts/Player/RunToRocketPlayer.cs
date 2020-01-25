using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunToRocketPlayer : RegularPlayer
{

    bool crouching = false;

    // Start is called before the first frame update
    new void Start()
    {
        // Call the base class Start Method
        base.Start();
        // Do Additional Config Here
        horizontalSensitivity = 0f;
    }

    // Update is called once per frame
    new void Update()
    {
        // Base Class update
        crouching = false;
        base.Update();
    }

    protected override void MoveUp(float howMuch) {
        rb.velocity = new Vector2(rb.velocity.x, 10f);
    }

    protected override void MoveDown(float howMuch) {
        crouching = true;
    }

    protected override void MoveHorizontally(float howMuch){ 
        rb.velocity = new Vector2(howMuch * 5f, rb.velocity.y);
    }

}
