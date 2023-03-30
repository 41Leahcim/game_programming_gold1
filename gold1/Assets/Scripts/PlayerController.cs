using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour {
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float jumpForce;
    private float rotation;
    private bool jumping;
    private Rigidbody m_rigidBody;
    [SerializeField] private StateMachine stateMachine;

    // Start is called before the first frame update
    void Start() {
        // Retrieve the RigidBody
        m_rigidBody = gameObject.GetComponent<Rigidbody>();

        // Set the default state to Idling
        stateMachine = new Idling(walkSpeed, runSpeed, jumpForce, m_rigidBody, transform);
    }

    // Update is called once per frame
    void Update() {
        // Move the player
        stateMachine.Move();

        // Rotate the player
        transform.Rotate(0, rotation * rotationSpeed * Time.deltaTime, 0);

        // Exit if the player presses escape
        if(Input.GetKeyDown(KeyCode.Escape)){
            Application.Quit(0);
        }
    }

    // Called when the player pressed awsd
    void OnMovement(InputValue input) {
        // Retrieve the input of the user
        Vector2 movement = input.Get<Vector2>();

        // Set the rotation to the input for the x-axis (ad)
        rotation = movement.x;

        // If the player doesn't press W, the player should Idle
        // If the player does press W and the player was Idling, the player should start walking
        if(movement.y <= 0){
            stateMachine = stateMachine.Idle();
        }else if(stateMachine.GetType() == typeof(Idling)){
            stateMachine = stateMachine.Walk();
        }
    }

    // Called when the player presses space
    void OnJump(InputValue input) {
        // The player should jump
        stateMachine = stateMachine.Jump();
    }

    // If the player hits an object, the player probably landed
    void OnCollisionEnter(Collision collision){
        stateMachine = stateMachine.Land();
    }

    // Called when the player presses or releases shift
    void OnSprint(InputValue input) {
        // The player should start running, if shift was pressed
        // The player should stop running, if shift was released and the player was running
        // If the player is walking when shift was released, the player should idle
        if(input.Get<float>() != 0){
            stateMachine = stateMachine.Run();
        }else if(stateMachine.GetType() == typeof(Running)){
            stateMachine = stateMachine.Walk();
        }else if(stateMachine.GetType() == typeof(Walking)){
            stateMachine = stateMachine.Idle();
        }
    }
}
