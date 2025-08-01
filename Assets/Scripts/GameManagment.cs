using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagment : MonoBehaviour
{
    //Names game manager
    public static GameManagment manager;

    public static bool westernHat, sentaiHat, noirHat, speedBuff, healthBuff, attackBuff, lowPolyWestern, lowPolyNoir, lowPolySentai;

    public static int coins = 0;
    public static int attackBoost = 0;
    public static int healthBoost = 0;
    public static float speedBoost = 0;

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
        Shop.SpeedUp += SpeedBuff;
        Shop.HealthUp += HealthBuff;
        Shop.AttackUp += AttackBuff;
        HiddenWestern.WesternPosterGot += PolyWestern;
        HiddenNoir.NoirPosterGot += PolyNoir;
        HiddenSentai.SentaiPosterGot += PolySentai;
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

    public static void CoinCounter(int numCoins)
    {
        coins += numCoins;
        Debug.Log("Number of coin is: " + coins);
    }

    void SpeedBuff()
    { 
        speedBuff = true;
        speedBoost = 0.5f;
    }

    void HealthBuff()
    {
        healthBuff = true;
        healthBoost = 10;
    }

    void AttackBuff()
    {
        attackBuff = true;
        attackBoost = 1;
    }

    void PolyWestern()
    {
        lowPolyWestern = true;
    }

    void PolyNoir()
    {
        lowPolyNoir = true;
    }

    void PolySentai()
    {
        lowPolySentai = true;
    }

}
