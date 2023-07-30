using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playground : MonoBehaviour
{
    public float speed;
    float viewHeight; // camera 높이 변수

    public Spawner spawner;

    private void Awake()
    {
        viewHeight = Camera.main.orthographicSize * 2;
    }

    private void Start()
    {
        spawner = GetComponentInChildren<Spawner>();
        //Debug.Log(spawner.spawnPoint.Length);
    }

    void Update()
    {
        Vector3 curPos = transform.position;                        // 배경 움직이기
        Vector3 nextPos = Vector3.down * speed * Time.deltaTime;
        transform.position = curPos + nextPos;

        if (transform.position.y < viewHeight * (-1))
        {
            //GameManager.Instance.poolManager.Delete(4); //장애물들 사라짐
            transform.position = transform.position + Vector3.up * viewHeight * 2;
            //spawner.Spawn();          //위로 올리면서 장애물도 같이 스폰
        }
    }
}
