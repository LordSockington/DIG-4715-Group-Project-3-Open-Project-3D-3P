using UnityEngine;
using UnityEngine.SceneManagement;

public class ToLevelWestern : MonoBehaviour
{
    public delegate void insideLevelWestern();
    public static event insideLevelWestern inLevelWestern;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && GameManagment.westernHat == false)
        {
            SceneManager.LoadScene("LevelWestern");

            inLevelWestern.Invoke();

            Debug.Log("In Level Western!");
        }
    }
}