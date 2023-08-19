using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Toilet_pre_last : MonoBehaviour
{
    public AudioSource shoesound; //구두소리
    public Image dialogue_UI; //대사창 UI
    public Image choose; //선택지
    public Text dialogue_right; //맞는 문 대사
    public Text dialogue_wrong; //틀린 문 대사

    //**텍스트
    [SerializeField] private Text txt_Dialogue;
    [SerializeField] private Dialogue[] dialogue;

    private int count = 0; //대사 횟수

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
            //**대사 나타나게
            txt_Dialogue.text = dialogue[count].dialogue;
            txt_Dialogue.gameObject.SetActive(true);

            if (count == 2) //3번째 대사 출력일 경우
            {
                txt_Dialogue.color = Color.red; //글씨 빨간색
                shoesound.Play(); //구두소리 재생
            }

            yield return new WaitForSeconds(2f);
            
            //if (shoesound.isPlaying)
                //shoesound.Stop(); //구두소리 끄기

            //**대사 사라지게
            txt_Dialogue.gameObject.SetActive(false);

            yield return new WaitForSeconds(0.5f);
            count++;
        }

        //**선택지 등장
        dialogue_UI.gameObject.SetActive(true);
        dialogue_wrong.gameObject.SetActive(false);
        dialogue_right.gameObject.SetActive(false);
        choose.gameObject.SetActive(true);
    }
}