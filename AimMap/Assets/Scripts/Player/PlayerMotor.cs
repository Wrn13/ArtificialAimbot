using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    public float speed = 5f;
    private bool isGrounded;
    private bool isSprinting;

    public float gravity = -9.8f;
    public float jumpHeight = 1.2f;
    public float sprintSpeed = 1.9f;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();     
        isSprinting = false;  
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = controller.isGrounded;
    }
    /*
        Recieve inputs for InputManager and apply to character.
    */
    public void ProcessMove(Vector2 input){
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        var movementVector = transform.TransformDirection(moveDirection) * speed;
        playerVelocity.x = movementVector.x;
        playerVelocity.z = movementVector.z;
        playerVelocity.y += gravity * Time.deltaTime;
        if(isGrounded && playerVelocity.y < 0)
            playerVelocity.y  = -1f;
        controller.Move(playerVelocity* Time.deltaTime);

        //Debug.Log("V = (" + playerVelocity.x + ", " + playerVelocity.y + ", " + playerVelocity.z +  ")\n Sprinting: " + isSprinting);
    }

    public void Jump(){
        if(isGrounded){
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }
    }

    public void Sprint(){
        
        if(isGrounded && !isSprinting){
            speed *= sprintSpeed;
        }else if(isGrounded && isSprinting){
            speed /= sprintSpeed;
        }
        isSprinting = !isSprinting;
    }
}
