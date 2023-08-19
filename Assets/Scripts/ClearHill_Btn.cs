using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ClearHill_Btn : MonoBehaviour
{
    public Image txtBox1; //대사 상자
    public Image txtBox2; //대사 상자
    public Image third_illust;
    public Image second_illust;

    public AudioSource audioSource;

    public void StopClick()
    {
        audioSource.Play();
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
}
