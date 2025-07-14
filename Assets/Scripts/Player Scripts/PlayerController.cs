using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //private Vector2 lookInput;
    private Vector2 moveInput;
    //private Rigidbody rb;

    public float jumpForce = 5;
    public float moveSpeed = 1;

    private CharacterController characterController;

    void Awake()
    {
        //rb = GetComponent<Rigidbody>(); Doesn't use a rigidbody right now
        characterController = GetComponent<CharacterController>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        PlayerMovement();
    }

    //Moves the character around, both pc and xbox support
    void OnMove(InputValue move)
    {
        moveInput = move.Get<Vector2>();
        Debug.Log(moveInput);
    }

    /* For if we are going to be able to look around
    void OnLook(InputValue look)
    {
        if (look.isPressed)
        {
            lookInput = look.Get<Vector2>();
            Debug.Log(lookInput);
        }
    }
    */

    void PlayerMovement()
    {
        Vector3 movement = new Vector3(moveInput.x, 0.0f, moveInput.y);
        characterController.SimpleMove(movement * moveSpeed);
    }

    //Allows the character to jump, both pc and xbox support
    //Need to add the jumping part, unsure if able to do with navmeshagent or have to use rigidbody which has weird results when used with navmeshagent
    //Doesn't work right now, and not sure if needed anyway.
    /*
    void OnJump(InputValue jump)
    {
        if (jump.isPressed)
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce, rb.linearVelocity.z);
            Debug.Log("Jumped!");
        }

    }
    */ 


}
