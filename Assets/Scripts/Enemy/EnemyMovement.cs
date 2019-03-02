using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    private Transform target;
    private float delta = 0.3f; // if the enemy is at pos + or - this
    private Enemy enemy;

    void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    void Update()
    {
        if (target)
        {
            Vector3 direction = target.position - transform.position;  // get the direction of the target
            transform.Translate(direction.normalized * enemy.stats.moveSpeed * Time.deltaTime, Space.World);    // move

            // the enemy has reached the point
            if (Vector3.Distance(transform.position, target.position) <= delta)
            {
                Explode();
            }
        }
    }

    public void SetTarget(Transform targetTransformWaypoint)
    {
        this.target = targetTransformWaypoint;
    }


    private void Explode()
    {
        if(enemy.stats.isBoss)
        {
            //
        }
        // PlayerStats.Lives -= enemy.stats.damage;
        // ANIMATION explosion

        Destroy(gameObject);
    }
}
