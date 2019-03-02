using System.Collections.Generic;
using UnityEngine;

public class GlobalEnemySpawner : MonoBehaviour
{
    public bool isSpawning = true;
    public float spawningRate = 1f;


    [SerializeField]
    private List<PlaceEnemySpawner> listPlaceEnemySpawner = new List<PlaceEnemySpawner>();  // uselly 4 (N, S, E, W)
    [SerializeField]
    private List<GameObject> listEnemyGO = new List<GameObject>();

    // intern
    private float time = 0f;


    void Update()
    {
        if(isSpawning)
        {
            time += Time.deltaTime;
            if(time >= spawningRate)
            {
                time = 0f;

                // spawn a random enemy randomly
                int numEnemyToSpawn = Random.Range(0, listEnemyGO.Count - 1);
                int numSpawner = Random.Range(0, listPlaceEnemySpawner.Count - 1);

                // spawn the enemy
                listPlaceEnemySpawner[numSpawner].SpawnEnemy(listEnemyGO[numEnemyToSpawn]);
            }
        }
    }
}
