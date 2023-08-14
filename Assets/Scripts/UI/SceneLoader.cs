using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    public static string loadScene; //가져올 씬 이름
    public static int loadType; //새로 시작 인지 이어 타기 인지


    void Start()
    {
        StartCoroutine(LoadScene());
    }

    public static void LoadSceneHandle(string _name, int _loadType)
    {
        loadScene = _name; //로딩할 씬의 이름
        loadType = _loadType;
        SceneManager.LoadScene("Loading");
    }

    IEnumerator LoadScene()
    {
        yield return null;
        if (loadType == 0)
            SceneManager.LoadScene("Load_Toilet");
        else if (loadType == 1)
            Debug.Log("헌게임");


    }
    
}