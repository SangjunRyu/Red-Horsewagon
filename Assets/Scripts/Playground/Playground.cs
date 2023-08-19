using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playground : MonoBehaviour
{
    public float speed;
    float viewHeight; // camera ���� ����
    private int SceneNum = 5;

    public bool isMove= true;                   // ������ ������ ��Ȱ��ȭ

    private SpriteRenderer spriteRenderer;
    public Sprite newSprite;                    // ������ ������ �ִ� ��������Ʈ�� ��ü, ������2,6,7����
    public GameObject[] roadCone;
    public GameObject endPoint;                 // ������ ���� Ž������Ʈ Ȱ��ȭ
    public GameObject parent;                          // ������ ��ֹ� ������ ����
    private Generator generator;
    public List<GameObject> itemObjects = new List<GameObject>();

    public GameObject[] playGround;

    private void Awake()
    {
        PlayerPrefs.SetInt("SceneNum", SceneNum);
        PlayerPrefs.Save();

        viewHeight = Camera.main.orthographicSize * 2;
        spriteRenderer = GetComponent<SpriteRenderer>();
        isMove = true;
        parent =  transform.parent.gameObject;
        generator = parent.GetComponentInChildren<Generator>();

        Item[] items = GetComponentsInChildren<Item>();
        foreach(Item item in items)
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
        spriteRenderer.sprite = newSprite;      // �ؿ��� ��ȭ�ϰ� ����÷�����. 
        foreach(GameObject cone in roadCone)
        {
            cone.SetActive(false);              // ������ ����
        }
        endPoint.SetActive(true);               // ��ȭ�ϸ鼭 ���� endpoint Ȱ��ȭ
        
        this.isMove = false;                   
        this.playGround[1].SetActive(false);
    }

}
