using UnityEngine;
using UnityEngine.AI;

public class EnemyBrain : MonoBehaviour
{
    private NavMeshAgent enemy;

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
    }

    void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            //enemy.SetDestination(player.transform.position); //Comment this line if you want the enemies to always follow the player no matter where
        }
    }
}
