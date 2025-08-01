using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class EnemyBrain : MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent enemy;

    public Animator animator;
    public int coinChance = 5;

    public float enemyHealth;
    public float stopDistance = 2f;
    public float rangedStopDistance = 10f;

    [SerializeField]
    private GameObject player;

    private float attackTimer = 0.0f;
    public float bufferTime = 1f;
    public float timeBetweenAttacks = 2f;

    public GameObject enemyObject;
    public GameObject bullet;

    public Transform bulletSpawn;

    public bool canAttack = false;
    private bool playerKilled = false;

    public bool isRanged = false;

    public delegate void coinDrop();
    public static event coinDrop CoinCounting;

    void Awake()
    {
        coinChance = Random.Range(1, coinChance+1);
        Debug.Log("CoinChance is 1/" + coinChance);
    }

    void Start()
    {
        enemy = GetComponent<UnityEngine.AI.NavMeshAgent>();

        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        if (isRanged == true)
        {
            enemy.stoppingDistance = rangedStopDistance;
        }
        else
        {
            enemy.stoppingDistance = stopDistance;
        }

    }

    void Update()
    {
         enemy.SetDestination(player.transform.position);    //Uncomment if we want the enemies to always follow the player no matter where

        if(enemyHealth <= 0)
        {
            playerKilled = true;
            Destroy(gameObject);
        }

        if (attackTimer < timeBetweenAttacks)
        {
            attackTimer += Time.deltaTime;

            Mathf.Clamp(attackTimer, 0, timeBetweenAttacks);

            // Sets attackTimer to "timeBetweenAttacks" in case of overflow
            if (attackTimer > timeBetweenAttacks)
            {
                attackTimer = timeBetweenAttacks;
            }
        }

        if (attackTimer == timeBetweenAttacks)
        {
            if (canAttack == true && isRanged == false)
            {
                StartCoroutine(EnemyAttack1());
            }
        }

    }

    void OnTriggerEnter (Collider collider)
    {
        if (collider.gameObject.tag == "Attack")
        {
            enemyHealth -= 1;
            //Debug.Log(enemyHealth);
        }
        if (collider.gameObject.tag == "Player")
        {
            canAttack = true;
        }
    }

    void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            if (isRanged == true)
            {
                if (attackTimer == timeBetweenAttacks)
                {
                    if (canAttack == true)
                    {
                        attackTimer = 0;
                        Debug.Log("Shot");
                        Instantiate(bullet, bulletSpawn.transform);
                    }
                }
            }
        }
    }

    void OnTriggerExit (Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        { 
            canAttack = false;
            animator.SetBool("Attacking", false);
        }
    }

    IEnumerator EnemyAttack1()
    {
        animator.SetBool("Attacking", true);
        enemyObject.GetComponent<BoxCollider>().enabled = true;

        yield return new WaitForSeconds(bufferTime);

        enemyObject.GetComponent<BoxCollider>().enabled = false;
        attackTimer = 0;
    }

    void OnDestroy()
    {
        if (playerKilled == true)
        {
            GameManagment.CoinCounter(coinChance);
        }
        
    }

}
