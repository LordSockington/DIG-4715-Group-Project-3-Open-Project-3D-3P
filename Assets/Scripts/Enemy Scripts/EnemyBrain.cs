using UnityEngine;
using UnityEngine.AI;

public class EnemyBrain : MonoBehaviour
{
    private NavMeshAgent enemy;

    public float enemyHealth;

    [SerializeField]
    private GameObject player;

    void Start()
    {
        enemy = GetComponent<UnityEngine.AI.NavMeshAgent>();

        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }

    void Update()
    {
         enemy.SetDestination(player.transform.position);    //Uncomment if we want the enemies to always follow the player no matter where

        if(enemyHealth <= 0)
        {
            Destroy(gameObject);
        }

        Debug.Log(enemyHealth);
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Attack")
        {
            enemyHealth -= 1;
        }
    }


}
