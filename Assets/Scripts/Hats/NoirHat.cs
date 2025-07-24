using UnityEngine;

public class NoirHat : MonoBehaviour
{
    public delegate void GetNoirHat();
    public static event GetNoirHat NoirHatGot;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            NoirHatGot.Invoke();
            Destroy(gameObject);
        }
    }

}
