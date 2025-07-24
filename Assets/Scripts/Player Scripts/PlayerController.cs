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
    public float rotationSpeed = 0;

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

    // Check for player contact with the ground to initiate a jump.
    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, distToGround + 0.1f);
    }

    // Adjusts rotation of player character
    private void AdjustRotation(Quaternion newRotate)
    {
        rb.rotation = newRotate;
    }

    // Movement logic
    void PlayerMovement()
    {
        Vector3 moveDirection = vertical * moveInput.y + horizontal * moveInput.x;
        Vector3 movement = new Vector3(moveInput.x, 0.0f, moveInput.y);

        rb.AddForce(moveDirection * moveSpeed, ForceMode.Acceleration);

        // Rotate the character to match the direction of travel
        rb.MoveRotation(Quaternion.Lerp(transform.localRotation, Quaternion.LookRotation(moveDirection, Vector3.up), Time.deltaTime * rotationSpeed));

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
