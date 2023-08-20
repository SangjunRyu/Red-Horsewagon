using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Btn : MonoBehaviour
{
    public Image txtBox1; //��� ����
    public Image txtBox2; //��� ����
    public Image third_illust;
    public Image second_illust;

    public AudioSource audioSource;

    public void StopClick()
    {

        GameManager.Instance.OnPlayerDead();

        //audioSource.Play();
        Invoke("LoadDieScene",3.5f);
    }

    private void LoadDieScene()
    {
        SceneManager.LoadScene("Die");
    }

    public void SingClick1()
    {
        txtBox1.gameObject.SetActive(false);
        txtBox2.gameObject.SetActive(true);
    }
    public void SingClick2()
    {
        second_illust.gameObject.SetActive(false);
        third_illust.gameObject.SetActive(true);
    }
    public void Run()
    {
        SceneManager.LoadScene("Toilet");  //���� �� �̵�
    }

    public void GoMain()
    {
        SceneManager.LoadScene("Main");
    }
}
