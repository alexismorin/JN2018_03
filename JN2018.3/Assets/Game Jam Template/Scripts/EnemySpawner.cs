using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //Variables
    public GameObject enemy;
    public GameObject spawnCentre;
    public float spawnTimeMin = 5.0f;
    public float spawnTimeMax = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", spawnTimeMin, spawnTimeMax);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemy()
    {
        Vector3 position = new Vector3(spawnCentre.transform.position.x + Random.Range(-5.0f, 5.0f), spawnCentre.transform.position.y, spawnCentre.transform.position.z + Random.Range(-5.0f, 5.0f));
        Instantiate(enemy, position, Quaternion.identity);
        //print("spawn at " + position);



        //var newEnemy = GameObject.Instantiate(enemy);
        //newEnemy.transform.position = Random.insideUnitSphere * 5;
        //newEnemy.transform.position.y = 1;
        //newEnemy.transform.position += spawnCentre.transform.position;
        //newEnemy.transform.position.y = 1.0f;
    }

}
