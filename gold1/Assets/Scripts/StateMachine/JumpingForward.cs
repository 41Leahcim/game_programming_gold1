using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingForward : StateMachine {
    private bool wasRunning;
    private float distanceToGround;

    public JumpingForward(StateMachine stateMachine, bool running) : base(stateMachine) {
        // Set the forward speed, you move forward faster while running but always slower when jumping
        float forwardSpeed = running? runningSpeed / 2 : walkingSpeed / 2;

        // Store whether the player was running
        wasRunning = running;

        // Jump forward with half the last speed
        m_RigidBody.AddForce(Vector3.up * jumpForce + transform.forward * forwardSpeed, ForceMode.Impulse);
    }

    public override StateMachine Land(){
        // Return to the state the player was in before jumping
        if(wasRunning){
            return new Running(this);
        }else{
            return new Walking(this);
        }
    }
}
