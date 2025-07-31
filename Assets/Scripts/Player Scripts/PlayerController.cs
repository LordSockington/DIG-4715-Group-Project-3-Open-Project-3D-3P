using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //private Vector2 lookInput;
    private Vector2 moveInput;

    public float jumpForce = 5;
    public float moveSpeed = 1;
    public float maxSpeed = 1;
    public float rotationSpeed = 0;

    public int health = 20;

    // Time between each attack
    private float attackTimer = 0.0f;

    private Rigidbody rb;
    public float distToGround = 1f;
    public Camera playerCam;

    private Vector3 vertical;
    private Vector3 horizontal;

    private Animator animator;

    private float verticalVelocity;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
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

        if (rb.linearVelocity != Vector3.zero)
        {
            animator.SetBool("IsMoving", true);
        }
        else
        {
            animator.SetBool("IsMoving", false);
        }

        if(health <= 0)
        {
            Destroy(gameObject);
        }
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
        return Physics.Raycast(transform.position, Vector3.down, distToGround);
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

        Vector3 currentVelocity = rb.linearVelocity;
        Vector3 xzVelocity = new Vector3(currentVelocity.x, 0f, currentVelocity.z);
        Vector3 yVelocity = new Vector3(0f, currentVelocity.y, 0f);

        xzVelocity = Vector3.ClampMagnitude(xzVelocity, maxSpeed);

        rb.linearVelocity = xzVelocity + yVelocity;

        // Rotate the character to match the direction of travel

        if (moveDirection != Vector3.zero)
        {
            rb.MoveRotation(Quaternion.Lerp(transform.localRotation, Quaternion.LookRotation(moveDirection, Vector3.up), Time.deltaTime * rotationSpeed));
        }

        if (movement == Vector3.zero && IsGrounded())
        {
            rb.linearVelocity = new Vector3(0, verticalVelocity, 0);
        }
    }

    // Functionality for first player attack.
    IEnumerator PlayerAttack1()
    {

        animator.SetBool("IsAttacking", true);
        //transform.GetChild(0).gameObject.SetActive(true);

        yield return new WaitForSeconds(0.5f);

        //transform.GetChild(0).gameObject.SetActive(false);
        animator.SetBool("IsAttacking", false);
    }

   //Allows the character to jump, both pc and xbox support
    void OnJump(InputValue jump)
    {
        if (jump.isPressed)
        {
            if (IsGrounded())
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Enemy")
        {
            health -= 1;
            Debug.Log(health);
        }
    }
}
