using UnityEngine;
using UnityEngine.SceneManagement;

public class ToLevelWestern : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player" && GameManagment.westernHat == false)
        {
            SceneManager.LoadScene("LevelWestern");
            Debug.Log("In Level Western!");
        }
    }
}