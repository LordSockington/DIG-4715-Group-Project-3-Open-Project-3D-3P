using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagment : MonoBehaviour
{
    //Names game manager
    public static GameManagment manager;

    public static bool westernHat, sentaiHat, noirHat;

    public static int coins = 0;

    void Awake()
    {
        //If game manager does not exist, do this:
        if (manager == null)
        {
            manager = this;
            DontDestroyOnLoad(this);
        }

        //If game manager equals something other than this scrpit, do this:
        else if (manager != this)
        {
            Destroy(gameObject);
        }

        WesternHat.WesternHatGot += LevelWesternDone;
        SentaiHat.SentaiHatGot += LevelSentaiDone;
        NoirHat.NoirHatGot += LevelNoirDone;
        EnemyBrain.CoinCounting += CoinCounter;
    }

    void LevelWesternDone()
    {
        westernHat = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void LevelSentaiDone()
    {
        sentaiHat = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void LevelNoirDone()
    {
        noirHat = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void CoinCounter()
    { 
        coins++;
        Debug.Log("Number of coin is: " + coins);
    }

}
