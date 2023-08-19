using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[System.Serializable]

public class EndPoint_corridor : MonoBehaviour
{
    Corridor corridor = null;
    
    public Canvas dialogue_UI; //���â UI(ĵ����)

    public bool isToilet; //ȭ��� ����

    [SerializeField] private Text txt_Dialogue; //��簡 �� �ؽ�Ʈ
    [SerializeField] private Dialogue[] dialogue; //��� ����
    //0: ���� ��� , 1: ���� ���, 2: �� ���� ���

    private bool isClear; //Ŭ���� �ߴ���
    private bool map_dialogue; //�� ������� ��� ����


    private void Awake()
    {
        map_dialogue = false; //�� ������� ��� ���� X
        gameObject.SetActive(false);
        dialogue_UI.gameObject.SetActive(false); //���â UI ��Ȱ��ȭ
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Player player = other.GetComponent<Player>();
        ItemQuest itemQuest = player.GetComponent<ItemQuest>();

        if (player)
        {
            corridor = GetComponentInParent<Corridor>();
            corridor.speed = 0f;
            Debug.Log("endpoint!");
            player.GetComponent<AudioSource>().Stop();  // �ȱ� ���� ����
        }

        if (itemQuest.isClear)
        {
            isClear = true;
            Debug.Log("Clear!");    // Ŭ����. �� ã��
            dialogue_UI.gameObject.SetActive(true); //���â Ȱ��ȭ
            txt_Dialogue.text = dialogue[1].dialogue; //���� ���
        }

        else
        {
            Debug.Log("Fail!");     // ��ã��. �ٽ��ϱ� ��
            
            if (!isToilet) //ȭ����� �ƴ϶�� 
            {
                dialogue_UI.gameObject.SetActive(true); //���â Ȱ��ȭ
                txt_Dialogue.text = dialogue[0].dialogue; //���� ���

            }
        }
    }

    private void Update()
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
                {
                    if (isToilet)
                        SceneManager.LoadScene("Corridor"); //���� ������
                    else
                        SceneManager.LoadScene("Clear_Corridor"); //���� ������
                }

            }

            else //Ŭ�������� ���ǹ����� ����
                GameManager.Instance.OnPlayerDead();
        }
    }
}
