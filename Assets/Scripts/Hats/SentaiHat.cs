using UnityEngine;

public class SentaiHat : MonoBehaviour
{
    public delegate void GetSentaiHat();
    public static event GetSentaiHat SentaiHatGot;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SentaiHatGot.Invoke();
            Destroy(gameObject);
        }
    }

}
