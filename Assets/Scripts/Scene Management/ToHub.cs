using UnityEngine;
using UnityEngine.SceneManagement;

public class ToHub : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (GameManagment.westernHat == true && GameManagment.sentaiHat == true && GameManagment.noirHat == true)
            {
                SceneManager.LoadScene("WinScreen");

            }
            else
            {
                SceneManager.LoadScene("MainHub");
                Debug.Log("In the Hub!");
            }

        }
    }

}
