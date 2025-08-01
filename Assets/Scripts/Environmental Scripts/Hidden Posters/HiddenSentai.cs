using UnityEngine;

public class HiddenSentai : MonoBehaviour
{
    public delegate void GetSentaiPoster();
    public static event GetSentaiPoster SentaiPosterGot;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SentaiPosterGot.Invoke();
            Destroy(gameObject);
        }
    }
}
