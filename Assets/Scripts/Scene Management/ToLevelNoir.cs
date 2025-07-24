using UnityEngine;
using UnityEngine.SceneManagement;

public class ToLevelNoir : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player" && GameManagment.noirHat == false)
        {
            SceneManager.LoadScene("LevelNoir");
            Debug.Log("In Level Noir!");
        }
    }
}
