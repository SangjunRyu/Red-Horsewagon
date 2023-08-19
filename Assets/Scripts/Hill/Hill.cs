using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hill : MonoBehaviour
{
    public float speed;
    float viewHeight; // camera ���� ����

    public bool isMove = true;                   // ������ ������ ��Ȱ��ȭ

    private SpriteRenderer spriteRenderer;
    

    public GameObject endPoint;                 // ������ ���� Ž������Ʈ Ȱ��ȭ
    public GameObject parent;                   // ������ ��ֹ� ������ ����
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
        yield return new WaitForSeconds(8f);
        this.generator.isEnd = true;            // ��ֹ� ���� ����. 

        yield return new WaitForSeconds(1f);
        foreach (GameObject item in itemObjects)
        {
            item.SetActive(true);               // ã�� ������Ʈ ��ġ
        }

        yield return new WaitForSeconds(0.6f);    // Ż�⹮ ������ �ϱ� 
        
        endPoint.SetActive(true);               // ��ȭ�ϸ鼭 ���� endpoint Ȱ��ȭ

        this.isMove = false;
        this.hill[1].SetActive(false);
    }
}
