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
            player.GetComponent<AudioSource>().Stop();  // �ȱ� ���� ����
        }

        if (itemQuest.isClear)
        {
            Debug.Log("Clear!");    // Ŭ����. �� ã��
                                    // ���� �������� �� �ε�
        }
        else
        {
            Debug.Log("Fail!");     // ��ã��. �ٽ��ϱ� ��
            GameManager.Instance.OnPlayerDead();
        }
    }
}
