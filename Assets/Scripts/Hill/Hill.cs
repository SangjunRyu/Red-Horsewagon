using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hill : MonoBehaviour
{
    public float speed;
    float viewHeight; // camera 높이 변수

    public bool isMove = true;                   // 끝날때 움직임 비활성화

    private SpriteRenderer spriteRenderer;
    

    public GameObject endPoint;                 // 끝날때 종점 탐지포인트 활성화
    public GameObject parent;                   // 끝날때 장애물 생성기 끄기
    private Generator generator;
    public List<GameObject> itemObjects = new List<GameObject>();

    public GameObject[] hill;
    private int SceneNum = 7;

    private void Awake()
    {
        PlayerPrefs.SetInt("SceneNum", SceneNum);
        PlayerPrefs.Save();

        viewHeight = Camera.main.orthographicSize * 2;
        spriteRenderer = GetComponent<SpriteRenderer>();
        isMove = true;
        parent = transform.parent.gameObject;
        generator = parent.GetComponentInChildren<Generator>();

        Item[] items = GetComponentsInChildren<Item>();
        foreach (Item item in items)
        {
            itemObjects.Add(item.gameObject);
        }
    }

    void Update()
    {
        Vector3 curPos = transform.position;                        // 배경 움직이기
        Vector3 nextPos = Vector3.down * speed * Time.deltaTime;
        transform.position = curPos + nextPos;

        if (transform.position.y < viewHeight * (-1))
        {
            transform.position = transform.position + Vector3.up * viewHeight * 2;
        }
        StartCoroutine(Timer());
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(8f);
        this.generator.isEnd = true;            // 장애물 생성 종료. 

        yield return new WaitForSeconds(1f);
        foreach (GameObject item in itemObjects)
        {
            item.SetActive(true);               // 찾기 오브젝트 배치
        }

        yield return new WaitForSeconds(0.6f);    // 탈출문 나오게 하기 
        
        endPoint.SetActive(true);               // 변화하면서 같이 endpoint 활성화

        this.isMove = false;
        this.hill[1].SetActive(false);
    }
}
