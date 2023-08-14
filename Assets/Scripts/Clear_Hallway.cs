using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Clear_Hallway : MonoBehaviour
{
    public Text Dialogue;
    public Text Dialogue2;
    private bool LoadScene = false;

    void Start()
    {
        Dialogue.gameObject.SetActive(false);
        Dialogue2.gameObject.SetActive(false);
        Invoke("ShowDialogue", 21.0f);
        Invoke("LoadScene_def", 25.7f);
    }

    void ShowDialogue()
    {
        Dialogue.gameObject.SetActive(true); //����ּ��� ON
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
