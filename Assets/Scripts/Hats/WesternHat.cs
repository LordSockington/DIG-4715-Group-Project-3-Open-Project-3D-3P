using UnityEngine;

public class WesternHat : MonoBehaviour
{
    public delegate void GetWesternHat();
    public static event GetWesternHat WesternHatGot;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            WesternHatGot.Invoke();
            Destroy(gameObject);
        }
    }

}
