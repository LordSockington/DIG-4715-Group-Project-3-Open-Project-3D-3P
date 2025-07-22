using UnityEngine;
using UnityEngine.SceneManagement;

public class ToLevelNoir : MonoBehaviour
{

    public delegate void insideLevelNoir();
    public static event insideLevelNoir inLevelNoir;

    void OnColliderEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player" && GameManagment.noirHat == false)
        {
            SceneManager.LoadScene("LevelNoir");

            inLevelNoir.Invoke();

            Debug.Log("In Level Noir!");
        }
    }
}
