using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemQuest : MonoBehaviour
{
    // item 획득시 clear. 아니면 실패, 다시하기 씬 로드

    public GameObject[] items;  // 찾아야 하는 아이템들. 찾는다면 좌상단에 작게 스프라이트 생김. 

                                // 아이템 생성은 1분 도달 직전에 진행해야 함.
                                // item.setActive(true)로 활성화시키는식으로 구현하기. 

    public int totalItem;
    public static int currentItem = 0;  // 현재 찾은 아이템 개수 초기화. 정적변수로 해서 저장공간을 공유

    public bool isClear = false;    // 다 찾아야 true로 
    Item item = null;

    private void Awake()
    {
        totalItem = items.Length;   // 총 아이템의 개수 저장

        foreach (var item in items)
        {
            item.SetActive(false);  // 시작시 item 꺼두기
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        item = collision.GetComponent<Item>();  // 부딪힌 것이 아이템인가?

        if (item)
        {
            currentItem++;    // 획득 아이템 증가
            Debug.Log("find!");
            AudioSource audio= collision.gameObject.GetComponent<AudioSource>(); //아이템 획득 음원추가
            audio.Play();
            SpriteRenderer sprite = collision.gameObject.GetComponent<SpriteRenderer>(); 
            sprite.enabled = false; // 아이템 사라지도록 하기 
        }
        if (currentItem == totalItem)
        {
            isClear = true;      // 모두 획득하였으므로 clear
            currentItem= 0;
        }
    }

}
