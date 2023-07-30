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
    //    int exit = Random.Range(0, 5);      // 첫 번째 줄. 0~4 중 선택          
    //    int enter = Random.Range(10, 15);   // 마지막 줄. 10~14 중 선택
    //    int midspace = Mathf.Abs((enter % 10) - exit) + 1;  // 가운데 빈 공간. eg) 2, 14=>[3칸]. 789 비워야
        
    //    int others = (spawnPoint.Length - 1) - (2 + midspace); // (16 - 1) - (2 + midspace)

    //    GameObject obstacle = GameManager.Instance.poolManager.Get(5);
    //    obstacle.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)].position;  // 자기자신빼고 자식만하려고 1씀

        //List<GameObject> obstacles = GameManager.Instance.poolManager.Gets(8);
        //foreach(GameObject item in obstacles)
        //{
        //    item.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)].position;
        //}

        //List<GameObject> obstacles = GameManager.Instance.poolManager.GetPools(others); // 생성된 장애물들을 리스트로 받음.
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