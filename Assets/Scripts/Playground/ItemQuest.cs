using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemQuest : MonoBehaviour
{
    // item ȹ��� clear. �ƴϸ� ����, �ٽ��ϱ� �� �ε�

    public GameObject[] items;  // ã�ƾ� �ϴ� �����۵�. ã�´ٸ� �»�ܿ� �۰� ��������Ʈ ����. 

                                // ������ ������ 1�� ���� ������ �����ؾ� ��.
                                // item.setActive(true)�� Ȱ��ȭ��Ű�½����� �����ϱ�. 

    public int totalItem;
    public static int currentItem = 0;  // ���� ã�� ������ ���� �ʱ�ȭ. ���������� �ؼ� ��������� ����

    public bool isClear = false;    // �� ã�ƾ� true�� 
    Item item = null;

    private void Awake()
    {
        totalItem = items.Length;   // �� �������� ���� ����

        foreach (var item in items)
        {
            item.SetActive(false);  // ���۽� item ���α�
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        item = collision.GetComponent<Item>();  // �ε��� ���� �������ΰ�?

        if (item)
        {
            currentItem++;    // ȹ�� ������ ����
            Debug.Log("find!");
            AudioSource audio= collision.gameObject.GetComponent<AudioSource>(); //������ ȹ�� �����߰�
            audio.Play();
            SpriteRenderer sprite = collision.gameObject.GetComponent<SpriteRenderer>(); 
            sprite.enabled = false; // ������ ��������� �ϱ� 
        }
        if (currentItem == totalItem)
        {
            isClear = true;      // ��� ȹ���Ͽ����Ƿ� clear
            currentItem= 0;
        }
    }

}
