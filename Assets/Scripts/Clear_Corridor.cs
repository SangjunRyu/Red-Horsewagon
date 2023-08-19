using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Clear_Corridor : MonoBehaviour
{
    public Text Dialogue;
    public Text Dialogue2;
    private bool LoadScene = false;
    private int SceneNum = 4;

    void Start()
    {
        PlayerPrefs.SetInt("SceneNum", SceneNum);
        PlayerPrefs.Save();

        Dialogue.gameObject.SetActive(false);
        Dialogue2.gameObject.SetActive(false);
        StartCoroutine(OnoffDialogue());
        Invoke("LoadScene_def", 21f);
    }

    IEnumerator OnoffDialogue()
    {
        yield return new WaitForSeconds(15f);
        Dialogue.gameObject.SetActive(true); //����ּ���
        yield return new WaitForSeconds(2f);
        Dialogue.gameObject.SetActive(false);
    }

    void LoadScene_def()
    {
        LoadScene = true; //�� �ѱ�� ��� Ȱ��ȭ
        Dialogue2.gameObject.SetActive(true); //����Ϸ��� Ŭ�� ON
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (LoadScene)
            {
                SceneManager.LoadScene("Playground");
            }
        }
    }
}
