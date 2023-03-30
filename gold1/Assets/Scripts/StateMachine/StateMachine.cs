using UnityEngine;

public abstract class StateMachine {
    protected float walkingSpeed;
    protected float runningSpeed;
    protected float jumpForce;
    protected Rigidbody m_RigidBody;
    protected Transform transform;

    // The constructor used for the initial state
    public StateMachine(float walking, float running,
        float jump, Rigidbody rb, Transform trans){
        walkingSpeed = walking;
        runningSpeed = running;
        jumpForce = jump;
        m_RigidBody = rb;
        transform = trans;
    }

    // Copy the state machine of the previous state to the current state
    public StateMachine(StateMachine other){
        walkingSpeed = other.walkingSpeed;
        runningSpeed = other.runningSpeed;
        jumpForce = other.jumpForce;
        m_RigidBody = other.m_RigidBody;
        transform = other.transform;
    }

    public virtual StateMachine Idle() {
        // Default return, if the current state can't change to this state
        return this;
    }

    public virtual StateMachine Walk() {
        // Default return, if the current state can't change to this state
        return this;
    }

    public virtual StateMachine Run() {
        // Default return, if the current state can't change to this state
        return this;
    }

    public virtual StateMachine Jump() {
        // Default return, if the current state can't change to this state
        return this;
    }

    public virtual void Move() {}

    public virtual StateMachine Land() {
        // Default return, if the current state can't change to this state
        return this;
    }
}
