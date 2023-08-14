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
    private static int currentItem = 0;  // ���� ã�� ������ ���� �ʱ�ȭ. ���������� �ؼ� ��������� ����

    public bool isClear = false;    // �� ã�ƾ� true�� 
    Item item = null;

    private void Awake()
    {
        totalItem = items.Length;   // �� �������� ���� ����
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        item = collision.GetComponent<Item>();  // �ε��� ���� �������ΰ�?

        if (item)
        {
            currentItem++;    // ȹ�� ������ ����
            Debug.Log("find!");
        }
        if(currentItem == totalItem)    
            isClear= true;      // ��� ȹ���Ͽ����Ƿ� clear
    }

}
