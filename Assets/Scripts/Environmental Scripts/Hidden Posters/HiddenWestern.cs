using UnityEngine;

public class HiddenWestern : MonoBehaviour
{
    public delegate void GetWesternHat();
    public static event GetWesternHat WesternPosterGot;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            WesternPosterGot.Invoke();
            Destroy(gameObject);
        }
    }
}
