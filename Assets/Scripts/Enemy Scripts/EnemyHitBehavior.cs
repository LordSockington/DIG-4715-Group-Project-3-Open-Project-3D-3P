using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class EnemyHitBehavior : MonoBehaviour
{
    private float attackTimer = 0.0f;

    public Transform enemy;

    public Vector3 offset = new Vector3(0, 0, 1);

    // Update is called once per frame
    void Update()
    {
        if (attackTimer < 1)
        {
            attackTimer += Time.deltaTime;

            Mathf.Clamp(attackTimer, 0, 1);

            // Sets attackTimer to 1 in case of overflow
            if (attackTimer > 1)
                attackTimer = 1;
        }

        transform.position = enemy.position + transform.forward + offset;
        transform.rotation = enemy.rotation;
    }

    void OnAttack(InputValue attack)
    {
        if (attackTimer == 1)
        {
            attackTimer = 0;
            StartCoroutine(EnemyAttack1());
        }

    }

    IEnumerator EnemyAttack1()
    {
        gameObject.GetComponent<BoxCollider>().enabled = true;

        yield return new WaitForSeconds(0.5f);

        gameObject.GetComponent<BoxCollider>().enabled = false;
    }
}
