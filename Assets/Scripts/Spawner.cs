using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
    public float spawnTime = 5f;
    public float spawnDelay = 2f;
    //public EnemyController[] enemies;
    //public int index;
    public EnemyController enemy;

	void Start () 
    {
        InvokeRepeating("Spawn", spawnDelay, spawnTime);        
	}

    void Spawn()
    {
        // Random loại enemy
        //int enemyIndex = Random.Range(0, enemies.Length);
        Instantiate(enemy, transform.position, Quaternion.identity);
    }
}
