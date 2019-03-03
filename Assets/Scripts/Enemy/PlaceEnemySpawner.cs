using System.Collections.Generic;
using UnityEngine;

public class PlaceEnemySpawner : MonoBehaviour
{
    [SerializeField]
    private Transform targetOfEnemySpawned; // the point that enemies have to reach

    private List<EnemySpawner> enemySpawner = new List<EnemySpawner>();

    private int nbChildSpawners = 0;

    void Start()
    {
        foreach(Transform child in transform) 
        {
            EnemySpawner es = child.gameObject.GetComponent<EnemySpawner>();
            es.SetTarget(targetOfEnemySpawned);
            enemySpawner.Add(es);
            ++nbChildSpawners;
        }
    }

    public void SpawnEnemy(GameObject enemyGO, float speed)
    {
        // random
        int numSpawner = Random.Range(0, nbChildSpawners);

        enemySpawner[numSpawner].SpawnEnemy(enemyGO, speed);
    }
}
