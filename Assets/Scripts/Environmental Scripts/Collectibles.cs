using UnityEngine;

public class Collectibles : MonoBehaviour
{
    public GameObject WesternPoster, NoirPoster, SentaiPoster;

    void Awake()
    {
        if (GameManagment.lowPolyWestern == true)
        {
            WesternPoster.SetActive(true);
        }

        if (GameManagment.lowPolyNoir == true)
        {
            NoirPoster.SetActive(true);
        }

        if (GameManagment.lowPolySentai == true)
        {
            SentaiPoster.SetActive(true);
        }
    }
}
