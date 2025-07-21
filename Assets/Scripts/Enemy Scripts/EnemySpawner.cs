using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    private GameObject player;

    [SerializeField]
    private GameObject enemyWestern;
    private GameObject enemySentai;
    private GameObject enemyNoir;

    private bool canSpawnEnemies = false;
    private bool levelWesternEnemies = false;
    private bool levelSentaiEnemies = false;
    private bool levelNoirEnemies = false;



    void Awake()
    {
        ToLevelWestern.inLevelWestern += levelWestern;
        ToLevelSentai.inLevelSentai += levelSentai;
        ToLevelNoir.inLevelNoir += levelNoir;
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
            if (levelWesternEnemies == true)
            {
                Invoke("SpawnsEnemyWestern", 5);
            }
            if (levelSentaiEnemies == true)
            {
                Invoke("SpawnsEnemySentai", 5);
            }
            if (levelNoirEnemies == true)
            {
                Invoke("SpawnsEnemyNoir", 5);
            }            
        }
    }

    void SpawnsEnemyWestern()
    {
        Instantiate(enemyWestern);
        Invoke("Wait", 0);
    }

    void SpawnsEnemySentai()
    {
        Instantiate(enemySentai);
        Invoke("Wait", 0);
    }

    void SpawnsEnemyNoir()
    {
        Instantiate(enemyNoir);
        Invoke("Wait", 0);
    }

    void StopSpawn()
    {
        canSpawnEnemies = false;
    }

    void levelWestern()
    {
        levelWesternEnemies = true;
        levelSentaiEnemies = false;
        levelNoirEnemies = false;
        canSpawnEnemies = true;
    }

    void levelSentai()
    {
        levelWesternEnemies = false;
        levelSentaiEnemies = true;
        levelNoirEnemies = false;
        canSpawnEnemies = true;
    }

    void levelNoir()
    {
        levelWesternEnemies = false;
        levelSentaiEnemies = false;
        levelNoirEnemies = true;
        canSpawnEnemies = true;
    }

}
