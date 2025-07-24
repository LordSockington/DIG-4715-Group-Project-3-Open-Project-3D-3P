using UnityEngine;

public class EnemyHitBehavior : MonoBehaviour
{
    private void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
            Destroy(transform.parent.gameObject);
    }
}
