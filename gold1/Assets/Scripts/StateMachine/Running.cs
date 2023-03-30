using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Running : StateMachine {
    public Running(StateMachine stateMachine) : base(stateMachine) {}

    public override StateMachine Idle() {
        // Slow down, instead of stopping to prevent high G-forces
        return Walk();
    }

    public override StateMachine Walk() {
        // Slow down
        return new Walking(this);
    }

    public override StateMachine Jump() {
        // Jump forward, as you still have some forward motion
        return new JumpingForward(this, true);
    }

    public override void Move() {
        // Move forward
        transform.Translate(Vector3.forward * runningSpeed * Time.deltaTime);
    }
}
