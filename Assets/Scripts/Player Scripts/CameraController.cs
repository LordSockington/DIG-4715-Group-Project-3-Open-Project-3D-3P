using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerPosition;

    private Vector3 offset = new Vector3(0, 0, 0);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = playerPosition.transform.position + offset;
        transform.LookAt(playerPosition);
    }
}
