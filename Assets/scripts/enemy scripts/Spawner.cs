using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField]
    private List<GameObject> enemies;
    [SerializeField]
    private float spawnRadius;

    private int numberOfEnemies = 3;
    // Start is called before the first frame update
    void Awake()
    {
        Transform playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        for(int i = 0; i < numberOfEnemies; i++)
        {
            Vector2 pos = new Vector2(playerTransform.position.x + Random.Range(-spawnRadius, spawnRadius), playerTransform.position.y + Random.Range(-spawnRadius, spawnRadius));

           var createdEnemy = Instantiate(enemies[0]);
           createdEnemy.transform.position = pos;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
