using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private Transform enemyTarget;

    public void SpawnEnemy(GameObject enemyGO)
    {
        // get the direction
        Vector3 relativePos = enemyTarget.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos);

        GameObject enemyCloneGO = (GameObject) Instantiate(enemyGO, transform.position, rotation);
        enemyCloneGO.GetComponent<EnemyMovement>().SetTarget(enemyTarget);
    }

    public void SetTarget(Transform target)
    {
        this.enemyTarget = target;
    }
}
