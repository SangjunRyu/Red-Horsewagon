using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Clear_Playground : MonoBehaviour
{
    public Image Illust;
    [SerializeField] private Text[] dialogue;

    private int cnt = 0; //�ؽ�Ʈ ��� Ƚ��
    private int TextDelay = 21; //ù �ؽ�Ʈ ��� ������
    private int SceneNum = 6;

    void Start()
    {
        PlayerPrefs.SetInt("SceneNum", SceneNum);
        PlayerPrefs.Save();

        for (int i = 0; i <= 16; i++)
            dialogue[i].gameObject.SetActive(false);
        Illust.gameObject.SetActive(false); //�Ϸ���Ʈ �� �ؽ�Ʈ ��ü OFF
        
        StartCoroutine(Illust_OnOff(12, true)); //�Ϸ���ƮON
        StartCoroutine(Illust_OnOff(19,false)); //�Ϸ���ƮOFF


        while (cnt <= 14) //�ؽ�Ʈ 15�� ���
        {
            StartCoroutine(Text_Show(cnt,TextDelay));
            cnt++;
            TextDelay += 1;
        }

        StartCoroutine(LastText_Show(35)); //"��?", ����Ϸ��� Ŭ�� ���
        
    }
    
    IEnumerator Illust_OnOff(float time, bool isIllust) //�Ϸ���Ʈ �ڷ�ƾ
    {
        yield return new WaitForSeconds(time);
        Illust.gameObject.SetActive(isIllust);
    }

    IEnumerator Text_Show(int num, float time) //�ؽ�Ʈ �ڷ�ƾ
    {
        yield return new WaitForSeconds(time);
        dialogue[num].gameObject.SetActive(true);
    }

    IEnumerator LastText_Show(float time) //������ �ؽ�Ʈ �ڷ�ƾ
    {
        yield return new WaitForSeconds(time);
        for (int i = 0; i <= 14; i++)
            dialogue[i].gameObject.SetActive(false);
        dialogue[15].gameObject.SetActive(true);
        dialogue[16].gameObject.SetActive(true);
    }

    private void Update()
    {
        if (dialogue[16].gameObject.activeSelf==true) //������ �ؽ�Ʈ�� Ȱ��ȭ �ƴٸ� �� �̵� ����
        {
            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene("Hill");
            }
        }
    }

}
