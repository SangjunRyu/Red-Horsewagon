using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint_playground : MonoBehaviour
{
    Playground playground = null;

    private void Awake()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Player player = other.GetComponent<Player>();
        ItemQuest itemQuest = player.GetComponent<ItemQuest>();

        if (player)
        {
            playground = GetComponentInParent<Playground>();
            playground.speed = 0f;
            Debug.Log("endpoint!");
            player.GetComponent<AudioSource>().Stop();  // 걷기 사운드 끄기
        }

        if (itemQuest.isClear)
        {
            Debug.Log("Clear!");    // 클리어. 다 찾음
                                    // 다음 스테이지 씬 로드
        }
        else
        {
            Debug.Log("Fail!");     // 못찾음. 다시하기 씬
            GameManager.Instance.OnPlayerDead();
        }
    }
}
