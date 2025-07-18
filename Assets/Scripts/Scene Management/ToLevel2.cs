using UnityEngine;
using UnityEngine.SceneManagement;

public class ToLevel2 : MonoBehaviour
{

    public delegate void insideLevel();
    public static event insideLevel inLevel2;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("Level2");

            inLevel2.Invoke();

            Debug.Log("In Level 2!");
        }
    }
}
