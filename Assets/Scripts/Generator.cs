using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public GameObject[] prefabs;
    public Transform[] spawnPoints;

    public float maxSpawnDelay;
    public float curSpawnDelay;

    private void Awake()
    {
        //spawnPoints = GetComponentsInChildren<Transform>();
    }

    void Update()
    {
        curSpawnDelay += Time.deltaTime;

        if(curSpawnDelay>maxSpawnDelay)
        {
            Generate();
            maxSpawnDelay = Random.Range(0.5f, 0.55f);
            curSpawnDelay = 0;
        }
    }

    void Generate()
    {
        int ranObstacle = Random.Range(1,9);
        int ranPoint = Random.Range(0,5);
        Instantiate(prefabs[ranObstacle], spawnPoints[ranPoint]);
    }

    void StaticObject(float spawnDelay1, float spawnDelay2)
    {

    }
}
