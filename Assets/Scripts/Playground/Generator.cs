using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public GameObject[] prefabs;
    public Transform[] spawnPoints;

    public float maxSpawnDelay;
    public float curSpawnDelay;
    public float spawntime1;
    public float spawntime2;

    public bool isEnd = false;

    private void Awake() 
    {
        Transform[] allTransforms = GetComponentsInChildren<Transform>();
        spawnPoints = new Transform[allTransforms.Length - 1];
        
        for (int i =0, j=0; i<allTransforms.Length; i++)
        {
            if (allTransforms[i] != transform)
            {
                spawnPoints[j] = allTransforms[i];
                j++;
            }
        }
    }

    void Update()
    {
        if (!isEnd)
        {
            curSpawnDelay += Time.deltaTime;

            if (curSpawnDelay > maxSpawnDelay)
            {
                Generate();
                maxSpawnDelay = Random.Range(spawntime1, spawntime2);
                curSpawnDelay = 0;
            }
        }
    }

    void Generate()
    {
        int ranObstacle = Random.Range(1,prefabs.Length);
        int ranPoint = Random.Range(0,spawnPoints.Length);
        Instantiate(prefabs[ranObstacle], spawnPoints[ranPoint]);
    }

    
}
