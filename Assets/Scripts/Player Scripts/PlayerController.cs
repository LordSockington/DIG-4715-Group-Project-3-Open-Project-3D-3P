using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //private Vector2 lookInput;
    private Vector2 moveInput;
    //private Rigidbody rb;

    public float jumpForce = 5;
    public float moveSpeed = 1;

    // Time between each attack
    private float attackTimer = 0.0f;

    //private CharacterController characterController;

    private Rigidbody rb;
    public float distToGround;
    public Camera playerCam;

    private Vector3 vertical;
    private Vector3 horizontal;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        //characterController = GetComponent<CharacterController>();
    }

    void Start()
    {

    }

    private void Update()
    {
        // Resets attackTimer back to 0 after attack is used.
        if (attackTimer < 1)
        {
            attackTimer += Time.deltaTime;

            Mathf.Clamp(attackTimer, 0, 1);

            // Sets attackTimer to 1 in case of overflow
            if (attackTimer > 1)
                attackTimer = 1;
        }

        vertical = playerCam.transform.forward;
        horizontal = playerCam.transform.right;

        vertical.y = 0f;
        horizontal.y = 0f;

        vertical.Normalize();
        horizontal.Normalize();
    }

    void LateUpdate()
    { 
        PlayerMovement();
    }

    //Moves the character around, both pc and xbox support
    void OnMove(InputValue move)
    {
        moveInput = move.Get<Vector2>();
        //Debug.Log(moveInput);
    }

    void OnAttack(InputValue attack)
    {
        if (attackTimer == 1)
        {
            attackTimer = 0;
            StartCoroutine(PlayerAttack1());
        }

    }

    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, distToGround + 0.1f);
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
        Vector3 moveDirection = vertical * moveInput.y + horizontal * moveInput.x;

        Vector3 movement = new Vector3(moveInput.x, 0.0f, moveInput.y);
        //characterController.SimpleMove(movement * moveSpeed);

        rb.AddForce(moveDirection * moveSpeed, ForceMode.Acceleration);

        if (movement == Vector3.zero && IsGrounded())
        {
            rb.AddForce(-rb.linearVelocity, ForceMode.Acceleration);
        }
    }

    // Functionality for first player attack.
    IEnumerator PlayerAttack1()
    {
        transform.GetChild(0).gameObject.SetActive(true);

        yield return new WaitForSeconds(0.5f);

        transform.GetChild(0).gameObject.SetActive(false);
    }

   //Allows the character to jump, both pc and xbox support
    void OnJump(InputValue jump)
    {
        if (jump.isPressed)
        {
            if(IsGrounded())
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

    }


}
