using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private Transform enemyTarget;

    public void SpawnEnemy(GameObject enemyGO)
    {
        GameObject enemyCloneGO = (GameObject) Instantiate(enemyGO, transform.position, transform.rotation);
        enemyCloneGO.GetComponent<EnemyMovement>().SetTarget(enemyTarget);
    }

    public void SetTarget(Transform target)
    {
        this.enemyTarget = target;
    }
}
