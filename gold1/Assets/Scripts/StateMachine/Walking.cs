using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walking : StateMachine {
    public Walking(StateMachine stateMachine) : base(stateMachine) {}

    public override StateMachine Idle() {
        // Stop!
        return new Idling(this);
    }

    public override StateMachine Run() {
        // Speed up
        return new Running(this);
    }

    public override StateMachine Jump() {
        // Jump forward, you still have some forward motion
        return new JumpingForward(this, false);
    }

    public override void Move() {
        // Move forward
        transform.Translate(Vector3.forward * walkingSpeed * Time.deltaTime);
    }
}
