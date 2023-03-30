using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idling : StateMachine {
    // Creates a new Idling mode
    public Idling(StateMachine stateMachine) : base(stateMachine) {}

    // Creates the default Idling mode
    public Idling(float walkingSpeed, float runningSpeed,
        float jumpForce, Rigidbody m_RigidBody, Transform transform)
         : base(walkingSpeed, runningSpeed, jumpForce, m_RigidBody, transform) {
    }
    
    public override StateMachine Walk() {
        // The player should walk
        return new Walking(this);
    }

    public override StateMachine Jump() {
        // You can jump when idling
        return new Jumping(this);
    }
}
