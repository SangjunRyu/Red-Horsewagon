using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PoolManager : MonoBehaviour
{
    private void Start()
    {
        
    }
    private void Update()
    {
        
    }


    //    public GameObject[] prefabs; // obstacles such as blood, crack ...
    //    public List<GameObject>[] pools;    // manage pooling

    //    private void Awake()
    //    {
    //        pools = new List<GameObject>[prefabs.Length];

    //        for(int index = 0; index < pools.Length; index++)
    //        {
    //            pools[index] = new List<GameObject>();  // initialize pools list
    //        }
    //        //Debug.Log(pools.Length) 4����;
    //    }

    //    public GameObject Get(int others)
    //    {
    //        GameObject select = null;

    //        for(int i=0; i< others; i++)
    //        {
    //            Debug.Log("for");
    //            int index = Random.Range(0, pools.Length);

    //            foreach (GameObject item in pools[index])
    //            {
    //                if (!item.activeSelf)
    //                {
    //                    select = item;
    //                    select.SetActive(true);
    //                    break;
    //                }
    //            }

    //            if (select == null)
    //            {
    //                select = Instantiate(prefabs[index], transform);
    //                pools[index].Add(select);
    //            }
    //        }
    //        return select;
    //    }

    //    public List<GameObject> Gets(int others)
    //    {
    //        GameObject select = null;
    //        List<GameObject> selects = new List<GameObject>();

    //        for (int i = 0; i < others; i++)
    //        {
    //            Debug.Log("for");
    //            int index = Random.Range(0, pools.Length);

    //            foreach (GameObject item in pools[index])
    //            {
    //                if (!item.activeSelf)
    //                {
    //                    select = item;
    //                    select.SetActive(true);
    //                    selects.Add(select);
    //                    break;
    //                }
    //            }

    //            if (select == null)
    //            {
    //                select = Instantiate(prefabs[index], transform);
    //                pools[index].Add(select);
    //                selects.Add(select);
    //            }
    //        }
    //        //return select;
    //        return selects;
}

    //public List<GameObject> GetPools(int others)
    //{
    //    GameObject select = null;
    //    int numOfobstacles = Random.Range(1, others);   // �ּ� 1�� �̻��� ��ֹ� ����
    //    List<GameObject> obstacles = null;

    //    for (int i = 0; i < others; i++)
    //    {
    //        int index = Random.Range(0, pools.Length);  // ��ֹ� ���� ����
    //        foreach (GameObject item in pools[index])
    //        {
    //            Debug.Log("foreach");
    //            if (!item.activeSelf)
    //            {
    //                Debug.Log("activate");
    //                select = item;
    //                select.SetActive(true);
    //                break;
    //            }
    //        }
    //        if (obstacles == null)
    //        {
    //            Debug.Log("instantiate");
    //            select = Instantiate(prefabs[index], transform);
    //            pools[index].Add(select);
    //        }
    //    }
    //    Debug.Log("..");
    //    return obstacles;   // ���� ������ ��ֹ� ���� ������Ʈ�� ���� ����Ʈ ��ȯ
    //}

//    public void Delete(int index) { 

//        for(int i=0; i<index; i++)
//        {
//            foreach(GameObject item in pools[i])
//            {
//                item.SetActive(false);
//            }
//        }
//    }
//}
