using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[System.Serializable]

public class EndPoint_hill : MonoBehaviour
{
    Hill Hill = null;

    //public Canvas dialogue_UI; //���â UI(ĵ����)

    //[SerializeField] private Text txt_Dialogue; //��簡 �� �ؽ�Ʈ
    //[SerializeField] private Dialogue[] dialogue; //��� ����
    //0: ���� ��� , 1: ���� ���, 2: �� ���� ���

    //private bool isClear; //Ŭ���� �ߴ���
    //private bool map_dialogue; //�� ������� ��� ����

    private void Awake()
    {
        //map_dialogue = false; //�� ������� ��� ���� X
        gameObject.SetActive(false);
        //dialogue_UI.gameObject.SetActive(false); //���â UI ��Ȱ��ȭ
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Player player = other.GetComponent<Player>();
        ItemQuest itemQuest = player.GetComponent<ItemQuest>();

        if (player)
        {
            Hill = GetComponentInParent<Hill>();
            Hill.speed = 0f;
            Debug.Log("endpoint!");
            player.GetComponent<AudioSource>().Stop();  // �ȱ� ���� ����
        }

        if (itemQuest.isClear)
        {
            //isClear = true;
            Debug.Log("Clear!");    // Ŭ����. �� ã��
            SceneManager.LoadScene("Clear_Hill"); //���� ������
            //dialogue_UI.gameObject.SetActive(true); //���â Ȱ��ȭ
            //txt_Dialogue.text = dialogue[1].dialogue; //���� ���
        }
        else
        {
            Debug.Log("Fail!");     // ��ã��. �ٽ��ϱ� ��
            GameManager.Instance.OnPlayerDead();

            //dialogue_UI.gameObject.SetActive(true); //���â Ȱ��ȭ
            //txt_Dialogue.text = dialogue[0].dialogue; //���� ���
        }
    }

    /*private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isClear) //Ŭ�������� Ŭ���� ����(���� ����)
            {
                if (!map_dialogue) //�����߰� �� ������� ���X
                {
                    txt_Dialogue.text = dialogue[2].dialogue;
                    map_dialogue = true;
                }
                else //�����߰� �� ������� ���O
                    SceneManager.LoadScene("Clear_Hill"); //���� ������
            }

            else //Ŭ�������� ���ǹ����� ����
                GameManager.Instance.OnPlayerDead();
        }
    }*/
}
