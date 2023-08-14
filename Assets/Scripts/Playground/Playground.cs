using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playground : MonoBehaviour
{
    public float speed;
    float viewHeight; // camera ���� ����

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
        Vector3 curPos = transform.position;                        // ��� �����̱�
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
        spriteRenderer.sprite = newSprite;      // �ؿ��� ��ȭ�ϰ� ����÷�����. 
        endPoint.SetActive(true);               // ��ȭ�ϸ鼭 ���� endpoint Ȱ��ȭ
        this.generator.isEnd = true;            // generator�� ���ߵ�. 
        this.isMove = false;                    // ���� �������� ����ø���, ���߲� ����. ���ʷ����͵� ����
    }

}
