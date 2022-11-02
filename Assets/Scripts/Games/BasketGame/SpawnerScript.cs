using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject Apple;
    float randX;
    Vector2 whereToSpawn;
    public float spawnRate = 2f;
    float nextSpawn = 0.0f;
   

    void Update()
    {
        if(Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            randX = Random.Range (-8.4f, 8.4f);
            whereToSpawn = new Vector3(transform.position.x, transform.position.y, -0.1f);
            Instantiate(Apple, whereToSpawn, Quaternion.identity);
        }
    }


}
