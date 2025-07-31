using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public delegate void bulletDamage();
    public static event bulletDamage rangeDamage;

    public Rigidbody rb;

    public float speed = 10f;

    private float timeElapsed = 0;

    public float timer = 5f;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * speed, ForceMode.Impulse);
    }

    void Update()
    {
        timeElapsed = Time.time;

        if (timeElapsed >= timer)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            rangeDamage.Invoke();
        }
        Destroy(gameObject);
    }

}
