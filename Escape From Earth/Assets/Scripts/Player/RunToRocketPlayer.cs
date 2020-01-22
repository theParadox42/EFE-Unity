using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunToRocketPlayer : RegularPlayer
{

    // Rigidbody2D rigidbody;

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
        base.Update();
    }

    protected override void MoveUp(float howMuch) {
        rb.velocity = new Vector2(rb.velocity.x, 5f);
    }

    protected override void MoveDown(float howMuch) {

    }

    protected override void MoveHorizontally(float howMuch){ 

    }

}
