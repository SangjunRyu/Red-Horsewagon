using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playground : MonoBehaviour
{
    public float speed;
    float viewHeight; // camera ���� ����

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
        Vector3 curPos = transform.position;                        // ��� �����̱�
        Vector3 nextPos = Vector3.down * speed * Time.deltaTime;
        transform.position = curPos + nextPos;

        if (transform.position.y < viewHeight * (-1))
        {
            //GameManager.Instance.poolManager.Delete(4); //��ֹ��� �����
            transform.position = transform.position + Vector3.up * viewHeight * 2;
            //spawner.Spawn();          //���� �ø��鼭 ��ֹ��� ���� ����
        }
    }
}
