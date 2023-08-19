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
    private float TextDelay = 17; //ù �ؽ�Ʈ ��� ������
    private int SceneNum = 6;

    void Start()
    {
        PlayerPrefs.SetInt("SceneNum", SceneNum);
        PlayerPrefs.Save();

        for (int i = 0; i <= 18; i++)
            dialogue[i].gameObject.SetActive(false);
        Illust.gameObject.SetActive(false); //�Ϸ���Ʈ �� �ؽ�Ʈ ��ü OFF
        
        StartCoroutine(Illust_OnOff(6, true)); //�Ϸ���ƮON
        StartCoroutine(Illust_OnOff(9,false)); //�Ϸ���ƮOFF


        while (cnt <= 16) //�ؽ�Ʈ 17�� ���
        {
            StartCoroutine(Text_Show(cnt,TextDelay));
            cnt++;
            TextDelay += 0.7f;
        }

        StartCoroutine(LastText_Show(36)); //"��?", ����Ϸ��� Ŭ�� ���
        
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
        for (int i = 0; i <= 16; i++)
            dialogue[i].gameObject.SetActive(false);
        dialogue[17].gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        dialogue[17].gameObject.SetActive(false);
        dialogue[18].gameObject.SetActive(true);
    }

    private void Update()
    {
        if (dialogue[18].gameObject.activeSelf==true) //������ �ؽ�Ʈ�� Ȱ��ȭ �ƴٸ� �� �̵� ����
        {
            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene("Hill");
            }
        }
    }

}
