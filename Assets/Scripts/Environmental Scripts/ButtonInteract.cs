using UnityEngine;
using UnityEngine.InputSystem;

public class ButtonInteract : MonoBehaviour
{
    public DoorController doorToOpen;
    private bool playerInRange = false;

    private PlayerInputActions inputActions;

    private void Awake()
    {
        inputActions = new PlayerInputActions();
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    void Update()
    {
        if (playerInRange && inputActions.Player.Interact.triggered)
        {
            Debug.Log(" Interact pressed (New Input System)");
            if (doorToOpen != null)
            {
                doorToOpen.ToggleDoor();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
