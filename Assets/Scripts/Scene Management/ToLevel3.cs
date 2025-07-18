using UnityEngine;
using UnityEngine.SceneManagement;

public class ToLevel3 : MonoBehaviour
{

    public delegate void insideLevel();
    public static event insideLevel inLevel3;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("Level3");

            inLevel3.Invoke();

            Debug.Log("In Level 3!");
        }
    }
}
