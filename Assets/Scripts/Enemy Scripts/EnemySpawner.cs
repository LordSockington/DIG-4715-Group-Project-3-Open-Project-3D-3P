using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    private GameObject player;

    [SerializeField]
    private GameObject levelEnemy, enemySpawnLocation;

    private bool canSpawnEnemies = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        Invoke("Wait", 0); //Starts spawning loop

        //Invoke("StopSpawn", 60); //For if we want the player to fight enemies for a set amount of time, if the player needs to get to the end then this is not needed.

    }

    void Wait()
    {
        if (canSpawnEnemies == true)
        {
            Invoke("SpawnsEnemy", 5);
        }
    }

    void SpawnsEnemy()
    {
        if (canSpawnEnemies == true)
        {
            Instantiate(levelEnemy, new Vector3 (enemySpawnLocation.transform.position.x, enemySpawnLocation.transform.position.y, enemySpawnLocation.transform.position.z), Quaternion.identity);
            Invoke("Wait", 0);
        }
    }

    void OnTriggerEnter(Collider trigger)
    {
        if (trigger.gameObject.tag == "Player")
        {
            canSpawnEnemies = false;
            Debug.Log("Spawn Off");
        }
    }

    void OnTriggerExit(Collider trigger)
    {
        if (trigger.gameObject.tag == "Player")
        {
            canSpawnEnemies = true;
            Debug.Log("Spawn On");
            Invoke("Wait", 0);
        }
    }

}
