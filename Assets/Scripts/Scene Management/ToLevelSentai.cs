using UnityEngine;
using UnityEngine.SceneManagement;

public class ToLevelSentai : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player" && GameManagment.sentaiHat == false)
        {
            SceneManager.LoadScene("LevelSentai");
            Debug.Log("In Level Sentai!");
        }
    }
}
