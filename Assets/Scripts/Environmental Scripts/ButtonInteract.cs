using UnityEngine;

public class ButtonInteract : MonoBehaviour
{
    public DoorController doorToOpen;
    private bool playerInRange = false;

    void Update()
    {
        if (playerInRange)
        {
            Debug.Log("Player is in range of button: " + gameObject.name);
        }

        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E key pressed near button: " + gameObject.name);

            if (doorToOpen != null)
            {
                Debug.Log("Calling ToggleDoor() on: " + doorToOpen.name);
                doorToOpen.ToggleDoor();
            }
            else
            {
                Debug.LogWarning("doorToOpen is not assigned on: " + gameObject.name);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered trigger for: " + gameObject.name);
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player exited trigger for: " + gameObject.name);
            playerInRange = false;
        }
    }
}
