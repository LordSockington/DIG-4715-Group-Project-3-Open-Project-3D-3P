using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class RangeHitBehavior : MonoBehaviour
{
    private float attackTimer = 0.0f;

    public GameObject enemyObject;

    private bool canAttack = false;

    public float bufferTime = 1f;

    public float timeBetweenAttacks = 2f;

    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
            if (canAttack == true)
            {
                StartCoroutine(EnemyAttack1());
            }
        }
    }

    IEnumerator EnemyAttack1()
    {
        enemyObject.GetComponent<BoxCollider>().enabled = true;

        yield return new WaitForSeconds(bufferTime);

        enemyObject.GetComponent<BoxCollider>().enabled = false;
        attackTimer = 0;
    }

}
