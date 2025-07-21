using UnityEngine;
using UnityEngine.SceneManagement;

public class ToLevelNoir : MonoBehaviour
{

    public delegate void insideLevelNoir();
    public static event insideLevelNoir inLevelNoir;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && GameManagment.noirHat == false)
        {
            SceneManager.LoadScene("LevelNoir");

            inLevelNoir.Invoke();

            Debug.Log("In Level Noir!");
        }
    }
}
