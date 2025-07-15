using System.Collections;
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

        // Resets attackTimer back to 0 after attack is used.
        if(attackTimer < 1)
        {
            attackTimer += Time.deltaTime;

            Mathf.Clamp(attackTimer, 0, 1);

            // Sets attackTimer to 1 in case of overflow
            if (attackTimer > 1)
                attackTimer = 1;
        }
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

    // Functionality for first player attack.
    IEnumerator PlayerAttack1()
    {
        transform.GetChild(0).gameObject.SetActive(true);

        yield return new WaitForSeconds(0.5f);

        transform.GetChild(0).gameObject.SetActive(false);
    }

    //Allows the character to jump, both pc and xbox support
    //Need to add the jumping part, unsure if able to do with navmeshagent or have to use rigidbody which has weird results when used with navmeshagent
    //Doesn't work right now, and not sure if needed anyway.
    /*
    void OnJump(InputValue jump)
    {
        if (jump.isPressed)
        {
            //playerVelocity.y = Mathf.Sqrt(jumpHeight * -2.0f * gravityValue);
        }

    }
    */


}
