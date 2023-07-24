using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playground : MonoBehaviour
{
    public float speed;
    float viewHeight; // camera 높이 변수

    private void Awake()
    {
        viewHeight = Camera.main.orthographicSize * 2;
    }

    void Update()
    {
        Vector3 curPos = transform.position;                        // 배경 움직이기
        Vector3 nextPos = Vector3.down * speed * Time.deltaTime;
        transform.position = curPos+ nextPos;

        if (transform.position.y < viewHeight * (-1))
        {
           transform.position = transform.position + Vector3.up * viewHeight * 2;
        }
    }
}
