using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : StateMachine {
    public Jumping(StateMachine stateMachine) : base(stateMachine) {
        // Jump up
        m_RigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    public override StateMachine Land(){
        // You landed, you are now idling again
        return new Idling(this);
    }
}
