using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playground : MonoBehaviour
{
    public float speed;
    float viewHeight; // camera 높이 변수

    public bool isMove= true;

    private SpriteRenderer spriteRenderer;
    public Sprite newSprite;
    public GameObject endPoint;
    GameObject parent;
    public Generator generator;

    private void Awake()
    {
        viewHeight = Camera.main.orthographicSize * 2;
        spriteRenderer = GetComponent<SpriteRenderer>();
        isMove = true;
        parent =  transform.parent.gameObject;
        generator = parent.GetComponentInChildren<Generator>();
    }

    private void Start()
    {

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
        yield return new WaitForSeconds(5f);
        spriteRenderer.sprite = newSprite;      // 밑에서 변화하고 끌어올려야함. 
        endPoint.SetActive(true);               // 변화하면서 같이 endpoint 활성화
        this.generator.isEnd = true;            // generator도 꺼야됨. 
        this.isMove = false;                    // 먼저 내려간건 끌어올리고, 나중껀 삭제. 제너레이터도 꺼야
    }

}
