using UnityEngine;
using UnityEngine.SceneManagement;

public class ToHub : MonoBehaviour
{

    public delegate void leftLevel();
    public static event leftLevel inHub;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("MainHub");

            inHub.Invoke();

            Debug.Log("In the Hub!");
        }
    }
}
