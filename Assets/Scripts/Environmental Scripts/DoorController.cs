using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Transform doorMesh;
    public Vector3 openRotation = new Vector3(0, 90, 0);
    public float openSpeed = 2f;

    private bool isOpen = false;

    public void ToggleDoor()
    {
        isOpen = !isOpen;
        Debug.Log(gameObject.name + ": Door is now " + (isOpen ? "OPEN" : "CLOSED"));
    }

    void Update()
    {
        if (doorMesh == null)
        {
            Debug.LogWarning("doorMesh is not assigned on " + gameObject.name);
            return;
        }

        Quaternion target = Quaternion.Euler(isOpen ? openRotation : Vector3.zero);
        doorMesh.localRotation = Quaternion.Slerp(doorMesh.localRotation, target, Time.deltaTime * openSpeed);
    }
}
