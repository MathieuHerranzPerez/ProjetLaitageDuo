using System.Collections.Generic;
using UnityEngine;

public class GlobalEnemySpawner : MonoBehaviour
{
    // Spawning stats
    public bool isSpawning = true;
    [Header("Game rules at start")]
    // Different Rates
    public float spawnRate = 4f;
    public float quadrantUnlockRate = 15f;
    public float enemySpeed =2f;

    // Different increase parameters
    [Header("Game variables increase deltas")]
    public float spawnRateDelta = 0.2f;
    public float quadrantUnlockRateDelta = 0f;
    public float enemySpeedDelta = 1f;

    // Spawning Zones 
    private int currentMaxQuadrantUnlocked = 0;
    [SerializeField] private List<PlaceEnemySpawner> listPlaceEnemySpawner = new List<PlaceEnemySpawner>();  // uselly 4 (N, S, E, W)

    // Type of ennemies spawning
    [SerializeField] private List<GameObject> listEnemyGO = new List<GameObject>();

    // intern
    private float spawnTime = 0f;
    private float quadrantUnlockTime = 0f;
    private float currentDeltaTime;
     
    void Start()
    {
        
    }

    void Update()
    {
        if(isSpawning)
        {
            currentDeltaTime = Time.deltaTime;
            spawnTime += currentDeltaTime;
            quadrantUnlockTime += currentDeltaTime;

            // Spawning ennemies
            if(spawnTime >= spawnRate)
            {
                spawnTime = 0f;

                // spawn a random enemy randomly
                int numEnemyToSpawn = Random.Range(0, listEnemyGO.Count);
                // in a random quadrant between the first one (north) and the max quadrant unlocked.
                int numSpawner = Random.Range(0, currentMaxQuadrantUnlocked+1);
                // actually spawn the enemy
                listPlaceEnemySpawner[numSpawner].SpawnEnemy(listEnemyGO[numEnemyToSpawn], enemySpeed);
            }

            // Unlocking quadrant
            if (quadrantUnlockTime >= quadrantUnlockRate)
            {
                quadrantUnlockTime = 0f;
                currentMaxQuadrantUnlocked = (currentMaxQuadrantUnlocked + 1)% listPlaceEnemySpawner.Count;
                 if (currentMaxQuadrantUnlocked % listPlaceEnemySpawner.Count == 1)
                 {
                    currentMaxQuadrantUnlocked %= listPlaceEnemySpawner.Count;

                    spawnRate -= spawnRateDelta;
                    enemySpeed += enemySpeedDelta;
                    quadrantUnlockRate -= quadrantUnlockRateDelta;
                }
            }
        }
    }
}
