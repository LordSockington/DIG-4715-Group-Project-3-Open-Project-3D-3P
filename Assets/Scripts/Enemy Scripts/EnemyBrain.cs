using UnityEngine;
using UnityEngine.AI;

public class EnemyBrain : MonoBehaviour
{
    private NavMeshAgent enemy;

    public float enemyHealth;
    public float stopDistance;

    [SerializeField]
    private GameObject player;

    public delegate void playerInRange();
    public static event playerInRange canAttack;

    public delegate void playerOutOfRange();
    public static event playerOutOfRange canNotAttack;

    void Start()
    {
        enemy = GetComponent<UnityEngine.AI.NavMeshAgent>();

        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        enemy.stoppingDistance = stopDistance;

    }

    void Update()
    {
         enemy.SetDestination(player.transform.position);    //Uncomment if we want the enemies to always follow the player no matter where

        if(enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Attack")
        {
            enemyHealth -= 1;
            Debug.Log(enemyHealth);
        }
        if (collider.gameObject.tag == "Player")
        {
            canAttack.Invoke();
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        { 
            canNotAttack.Invoke();
        }
    }


}
