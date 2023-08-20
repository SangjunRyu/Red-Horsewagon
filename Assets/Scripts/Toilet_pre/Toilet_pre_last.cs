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
    public Text redhorsewagon; //�������� ���
    public Text dialogue_txt; //���â ���


    [SerializeField] private Dialogue[] dialogue; //��� ����

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
        dialogue_UI.gameObject.SetActive(false);//��� ��Ȱ��ȭ

        shoesound.Play(); //���μҸ�
        yield return new WaitForSeconds(2f);
        redhorsewagon.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        redhorsewagon.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);

        //**������ ����
        dialogue_UI.gameObject.SetActive(true);
        dialogue_txt.gameObject.SetActive(false);
        choose.gameObject.SetActive(true);
    }
}