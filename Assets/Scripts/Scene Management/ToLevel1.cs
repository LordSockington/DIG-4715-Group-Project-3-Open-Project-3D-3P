using UnityEngine;
using UnityEngine.SceneManagement;

public class ToLevel1 : MonoBehaviour
{
    public delegate void insideLevel();
    public static event insideLevel inLevel1;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("Level1");

            inLevel1.Invoke();

            Debug.Log("In Level 1!");
        }
    }
}