using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class Spawner : MonoBehaviour
{
    //public Transform[] spawnPoint;
    //public SpawnData[] spawnData;
    //public List<Transform> spawnList;
    //public HashSet<Transform> spawns;

    //private void Awake()
    //{
    //    spawnPoint = GetComponentsInChildren<Transform>();
    //    spawnList = new List<Transform>();
    //    spawns = new HashSet<Transform>();

    //    foreach(Transform position in GetComponentsInChildren<Transform>())
    //    {
    //        spawnList.Add(position);
    //        spawns.Add(position);
    //    }
    //    Debug.Log(spawnList.Count);
    //}

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.H))
    //    {
    //        Spawn();
    //    }
    //}

    //public void Spawn()
    //{
    //    int exit = Random.Range(0, 5);      // ù ��° ��. 0~4 �� ����          
    //    int enter = Random.Range(10, 15);   // ������ ��. 10~14 �� ����
    //    int midspace = Mathf.Abs((enter % 10) - exit) + 1;  // ��� �� ����. eg) 2, 14=>[3ĭ]. 789 �����
        
    //    int others = (spawnPoint.Length - 1) - (2 + midspace); // (16 - 1) - (2 + midspace)

    //    GameObject obstacle = GameManager.Instance.poolManager.Get(5);
    //    obstacle.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)].position;  // �ڱ��ڽŻ��� �ڽĸ��Ϸ��� 1��

        //List<GameObject> obstacles = GameManager.Instance.poolManager.Gets(8);
        //foreach(GameObject item in obstacles)
        //{
        //    item.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)].position;
        //}

        //List<GameObject> obstacles = GameManager.Instance.poolManager.GetPools(others); // ������ ��ֹ����� ����Ʈ�� ����.
        //foreach(GameObject obstacle in obstacles)
        //{
        //    obstacle.transform.position = spawnList[Random.Range(1,spawnPoint.Length)].position;
        //    Debug.Log("obstacles");
        //}
//    }
}

//[System.Serializable]
//public class SpawnData
//{

//}