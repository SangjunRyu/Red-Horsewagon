using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Toilet_pre_last : MonoBehaviour
{
    public AudioSource shoesound; //���μҸ�
    public Image dialogue_UI; //���â UI
    public Image choose; //������
    public Text dialogue_right; //�´� �� ���
    public Text dialogue_wrong; //Ʋ�� �� ���

    //**�ؽ�Ʈ
    [SerializeField] private Text txt_Dialogue;
    [SerializeField] private Dialogue[] dialogue;

    private int count = 0; //��� Ƚ��

    private void Awake()
    {
        shoesound = GetComponent<AudioSource>();
    }

    private void Start()
    {
        StartCoroutine(Text_Show());
    }

    IEnumerator Text_Show()
    {
        yield return new WaitForSeconds(0.5f);
        while (count < 3)
        {
            //**��� ��Ÿ����
            txt_Dialogue.text = dialogue[count].dialogue;
            txt_Dialogue.gameObject.SetActive(true);

            if (count == 2) //3��° ��� ����� ���
            {
                txt_Dialogue.color = Color.red; //�۾� ������
                shoesound.Play(); //���μҸ� ���
            }

            yield return new WaitForSeconds(2f);
            
            //if (shoesound.isPlaying)
                //shoesound.Stop(); //���μҸ� ����

            //**��� �������
            txt_Dialogue.gameObject.SetActive(false);

            yield return new WaitForSeconds(0.5f);
            count++;
        }

        //**������ ����
        dialogue_UI.gameObject.SetActive(true);
        dialogue_wrong.gameObject.SetActive(false);
        dialogue_right.gameObject.SetActive(false);
        choose.gameObject.SetActive(true);
    }
}