using UnityEngine;

public class HiddenNoir : MonoBehaviour
{
    public delegate void GetNoirPoster();
    public static event GetNoirPoster NoirPosterGot;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            NoirPosterGot.Invoke();
            Destroy(gameObject);
        }
    }
}
