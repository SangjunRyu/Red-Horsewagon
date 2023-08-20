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
    public Text redhorsewagon; //빨간마차 대사
    public Text dialogue_txt; //대사창 대사


    [SerializeField] private Dialogue[] dialogue; //대사 모음

    private void Awake()
    {
        shoesound = GetComponent<AudioSource>();
    }

    private void Start()
    {
        redhorsewagon.gameObject.SetActive(false);
        StartCoroutine(Text_Show());
    }

    IEnumerator Text_Show()
    {
        for (int i=0; i<2; i++)
        {
            dialogue_txt.gameObject.SetActive(false);
            yield return new WaitForSeconds(0.5f);
            dialogue_txt.text = dialogue[i].dialogue;
            dialogue_txt.gameObject.SetActive(true);
            yield return new WaitForSeconds(2);
        }
        dialogue_UI.gameObject.SetActive(false);//대사 비활성화

        shoesound.Play(); //구두소리
        yield return new WaitForSeconds(2f);
        redhorsewagon.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        redhorsewagon.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);

        //**선택지 등장
        dialogue_UI.gameObject.SetActive(true);
        dialogue_txt.gameObject.SetActive(false);
        choose.gameObject.SetActive(true);
    }
}