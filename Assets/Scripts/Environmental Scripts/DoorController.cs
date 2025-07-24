using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Transform doorToRotate;  
    public Vector3 openRotationOffset = new Vector3(0, 90, 0); 
    public float openSpeed = 10f;

    private bool isOpen = false;
    private Quaternion closedRotation;
    private Quaternion openRotation;

    void Start()
    {
        if (doorToRotate == null)
        {
            Debug.LogError("DoorController: doorToRotate is not assigned.");
            return;
        }

        
        closedRotation = doorToRotate.localRotation;

        
        openRotation = closedRotation * Quaternion.Euler(openRotationOffset);
    }

    public void ToggleDoor()
    {
        isOpen = !isOpen;
        Debug.Log(" Door toggled: " + (isOpen ? "OPEN" : "CLOSED"));
    }

    void Update()
    {
        if (doorToRotate == null) return;

        Quaternion target = isOpen ? openRotation : closedRotation;
        doorToRotate.localRotation = Quaternion.Slerp(doorToRotate.localRotation, target, Time.deltaTime * openSpeed);
    }
}
