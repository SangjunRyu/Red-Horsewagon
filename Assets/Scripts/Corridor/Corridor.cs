using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corridor : MonoBehaviour
{
    public float speed;
    float viewHeight; // camera 높이 변수

    public bool isMove = true;                   // 끝날때 움직임 비활성화

    private SpriteRenderer spriteRenderer;
    public Sprite newSprite;                    // 끝날때 종점이 있는 스프라이트로 교체

    public GameObject endPoint;                 // 끝날때 종점 탐지포인트 활성화
    public GameObject parent;                   // 끝날때 장애물 생성기 끄기
    private Generator generator;
    public List<GameObject> itemObjects = new List<GameObject>();

    public GameObject[] corridor;

    public bool gameStart;  // 게임 재개하기 or 나가기 구분용 변수


    private int SceneNum = 3;
    void Start()
    {
        PlayerPrefs.SetInt("SceneNum", SceneNum);
        PlayerPrefs.Save();
        gameStart= true;
    }
    private void Awake()
    {
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
        //while (gameStart)   // 나가기를 누르지 않았을 경우에 
        //{
            Vector3 curPos = transform.position;                        // 배경 움직이기
            Vector3 nextPos = Vector3.down * speed * Time.deltaTime;
            transform.position = curPos + nextPos;

            if (transform.position.y < viewHeight * (-1))
            {
                transform.position = transform.position + Vector3.up * viewHeight * 2;
            }
            StartCoroutine(Timer());
        //}
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

        yield return new WaitForSeconds(1f);    // 탈출문 나오게 하기 
        spriteRenderer.sprite = newSprite;      // 밑에서 변화하고 끌어올려야함. 
       
        endPoint.SetActive(true);               // 변화하면서 같이 endpoint 활성화

        this.isMove = false;
        this.corridor[1].SetActive(false);
    }

}
