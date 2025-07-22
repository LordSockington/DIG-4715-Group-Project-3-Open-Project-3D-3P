using UnityEngine;
using UnityEngine.SceneManagement;

public class ToLevelSentai : MonoBehaviour
{

    public delegate void insideLevelSentai();
    public static event insideLevelSentai inLevelSentai;

    void OnColliderEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player" && GameManagment.sentaiHat == false)
        {
            SceneManager.LoadScene("LevelSentai");

            inLevelSentai.Invoke();

            Debug.Log("In Level Sentai!");
        }
    }
}
