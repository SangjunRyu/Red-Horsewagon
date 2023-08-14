using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    public static string loadScene; //������ �� �̸�
    public static int loadType; //���� ���� ���� �̾� Ÿ�� ����


    void Start()
    {
        StartCoroutine(LoadScene());
    }

    public static void LoadSceneHandle(string _name, int _loadType)
    {
        loadScene = _name; //�ε��� ���� �̸�
        loadType = _loadType;
        SceneManager.LoadScene("Loading");
    }

    IEnumerator LoadScene()
    {
        yield return null;
        if (loadType == 0)
            SceneManager.LoadScene("Load_Toilet");
        else if (loadType == 1)
            Debug.Log("�����");


    }
    
}