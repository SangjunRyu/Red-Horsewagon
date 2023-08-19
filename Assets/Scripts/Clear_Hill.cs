using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


[System.Serializable]

public class Clear_Hill : MonoBehaviour
{
    //[SerializeField] private Text txt_Dialogue;
    //[SerializeField] private Button choose;
    //[SerializeField] private Dialogue[] dialogue;

    public Image txtBox;
    public Image txtBox1; //��� ����
    public Image txtBox2; //��� ����

    public Image first_illust; //�������� �׸�
    public Image second_illust; //�������� ���� �Ϸ���Ʈ
    public Image third_illust; //

    private int SceneNum = 8;

    void Start()
    {
        PlayerPrefs.SetInt("SceneNum", SceneNum);
        PlayerPrefs.Save();

        txtBox.gameObject.SetActive(false);
        txtBox1.gameObject.SetActive(false);
        txtBox2.gameObject.SetActive(false);

        first_illust.gameObject.SetActive(true);
        second_illust.gameObject.SetActive(false);
        third_illust.gameObject.SetActive(false);


        StartCoroutine(Hide_first(3)); //ù��° �Ϸ�/��� ����, �ι�° �Ϸ� ǥ��

        StartCoroutine(Show_second(5)); //�ι�° ��� �� ������ ǥ��

    }

    IEnumerator Hide_first(float time)
    {
        yield return new WaitForSeconds(1.0f);
        txtBox.gameObject.SetActive(true);

        yield return new WaitForSeconds(time);
        first_illust.gameObject.SetActive(false);
        second_illust.gameObject.SetActive(true);
        txtBox1.gameObject.SetActive(false);

    }

    IEnumerator Show_second(float time)
    {
        yield return new WaitForSeconds(time);
        txtBox1.gameObject.SetActive(true);
    }

    void Update()
    {
       
    }
}
