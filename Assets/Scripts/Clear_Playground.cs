using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Clear_Playground : MonoBehaviour
{
    public Image Illust;
    [SerializeField] private Text[] dialogue;

    private int cnt = 0; //텍스트 출력 횟수
    private int TextDelay = 21; //첫 텍스트 출력 딜레이
    private int SceneNum = 6;

    void Start()
    {
        PlayerPrefs.SetInt("SceneNum", SceneNum);
        PlayerPrefs.Save();

        for (int i = 0; i <= 16; i++)
            dialogue[i].gameObject.SetActive(false);
        Illust.gameObject.SetActive(false); //일러스트 및 텍스트 전체 OFF
        
        StartCoroutine(Illust_OnOff(12, true)); //일러스트ON
        StartCoroutine(Illust_OnOff(19,false)); //일러스트OFF


        while (cnt <= 14) //텍스트 15개 출력
        {
            StartCoroutine(Text_Show(cnt,TextDelay));
            cnt++;
            TextDelay += 1;
        }

        StartCoroutine(LastText_Show(35)); //"왜?", 계속하려면 클릭 출력
        
    }
    
    IEnumerator Illust_OnOff(float time, bool isIllust) //일러스트 코루틴
    {
        yield return new WaitForSeconds(time);
        Illust.gameObject.SetActive(isIllust);
    }

    IEnumerator Text_Show(int num, float time) //텍스트 코루틴
    {
        yield return new WaitForSeconds(time);
        dialogue[num].gameObject.SetActive(true);
    }

    IEnumerator LastText_Show(float time) //마지막 텍스트 코루틴
    {
        yield return new WaitForSeconds(time);
        for (int i = 0; i <= 14; i++)
            dialogue[i].gameObject.SetActive(false);
        dialogue[15].gameObject.SetActive(true);
        dialogue[16].gameObject.SetActive(true);
    }

    private void Update()
    {
        if (dialogue[16].gameObject.activeSelf==true) //마지막 텍스트가 활성화 됐다면 씬 이동 가능
        {
            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene("Hill");
            }
        }
    }

}
