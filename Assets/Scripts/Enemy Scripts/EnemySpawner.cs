using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    private GameObject player;

    [SerializeField]
    private GameObject enemy1;
    private GameObject enemy2;
    private GameObject enemy3;

    private bool canSpawnEnemies = false;
    private bool level1Enemies = false;
    private bool level2Enemies = false;
    private bool level3Enemies = false;



    void Awake()
    {
        ToLevel1.inLevel1 += level1;
        ToLevel2.inLevel2 += level2;
        ToLevel3.inLevel3 += level3;
        ToHub.inHub += StopSpawn;
    }

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
            if (level1Enemies == true)
            {
                Invoke("SpawnsEnemy1", 5);
            }
            if (level2Enemies == true)
            {
                Invoke("SpawnsEnemy2", 5);
            }
            if (level3Enemies == true)
            {
                Invoke("SpawnsEnemy3", 5);
            }            
        }
    }

    void SpawnsEnemy1()
    {
        Instantiate(enemy1);
        Invoke("Wait", 0);
    }

    void SpawnsEnemy2()
    {
        Instantiate(enemy2);
        Invoke("Wait", 0);
    }

    void SpawnsEnemy3()
    {
        Instantiate(enemy3);
        Invoke("Wait", 0);
    }

    void StopSpawn()
    {
        canSpawnEnemies = false;
    }

    void level1()
    {
        level1Enemies = true;
        level2Enemies = false;
        canSpawnEnemies = true;
    }

    void level2()
    {
        level1Enemies = false;
        level2Enemies = true;
        level3Enemies = false;
        canSpawnEnemies = true;
    }

    void level3()
    {
        level1Enemies = false;
        level2Enemies = false;
        level3Enemies = true;
        canSpawnEnemies = true;
    }

}
