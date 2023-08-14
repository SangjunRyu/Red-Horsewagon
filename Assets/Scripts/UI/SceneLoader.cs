using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static int SceneNum; //가져올 씬 넘버


    void Start()
    {
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        yield return null;
        if (SceneNum == 1)
            SceneManager.LoadScene("Toilet_choose");
        else if (SceneNum == 2)
            SceneManager.LoadScene("Toilet");
        else if (SceneNum == 3)
            SceneManager.LoadScene("Hallway");
        else if (SceneNum == 4)
            SceneManager.LoadScene("Clear_Hallway");
        else if (SceneNum == 5)
            SceneManager.LoadScene("Playground");
        else if (SceneNum == 6)
            SceneManager.LoadScene("Clear_Playground");
        else if (SceneNum == 7)
            SceneManager.LoadScene("Hill");
        else if (SceneNum == 8)
            SceneManager.LoadScene("Clear_Hill");

    }
    
}