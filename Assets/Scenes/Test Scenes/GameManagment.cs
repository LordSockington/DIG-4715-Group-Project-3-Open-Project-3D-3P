using UnityEngine;

public class GameManagment : MonoBehaviour
{
    //Names game manager
    public static GameManagment manager;

    public static bool westernHat, sentaiHat, noirHat;

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

    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LevelWesternDone()
    {
        westernHat = true;
    }

    void LevelSentaiDone()
    {
        sentaiHat = true;
    }

    void LevelNoirDone()
    {
        noirHat = true;
    }


}
