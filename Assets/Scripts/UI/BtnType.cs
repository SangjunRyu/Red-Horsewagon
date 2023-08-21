using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum BTNType
{
    New,
    Continue,
    Quit,
    Extra
}

public class BtnType : MonoBehaviour
{
    public BTNType currentType;

    private void Awake()
    {
        Debug.Log("Is First Run?: " + !PlayerPrefs.HasKey("FirstRun"));    // 처음시작인지확인
        if (PlayerPrefs.GetInt("GameCleared") == 1)
        {
            Debug.Log("cleared");
        }
    }
    public void OnBtnClick()
    {
        switch(currentType)
        {
            case BTNType.New:
                {
                    Debug.Log("new");
                    SceneManager.LoadScene("Start"); //새로 시작이면 스타트 씬 이동
                    break;
                }
            case BTNType.Continue:
                {
                    if (!PlayerPrefs.HasKey("FirstRun"))
                    {
                        PlayerPrefs.SetInt("FirstRun", 1);
                        PlayerPrefs.Save();
                        SceneManager.LoadScene("Start");
                        break;
                    }   
                    int Scene = PlayerPrefs.GetInt("SceneNum");

                    if (Scene == 0)
                    {
                        Debug.Log("start");
                        SceneManager.LoadScene("Start");
                    }
                    else if (Scene == 1)
                        SceneManager.LoadScene("Toilet_pre");
                    else if (Scene == 2)
                        SceneManager.LoadScene("Toilet");
                    else if (Scene == 3)
                    {
                        Debug.Log("corridor");
                        SceneManager.LoadScene("Corridor");
                    }
                    else if (Scene == 4)
                        SceneManager.LoadScene("Clear_Corridor");
                    else if (Scene == 5)
                        SceneManager.LoadScene("Playground");
                    else if (Scene == 6)
                        SceneManager.LoadScene("Clear_Playground");
                    else if (Scene == 7)
                        SceneManager.LoadScene("Hill");
                    else if (Scene == 8)
                        SceneManager.LoadScene("Clear_Hill");

                    break;
                }

            case BTNType.Quit:
                //Debug.Log("끝");
                Application.Quit();
                break;

            case BTNType.Extra:
                SceneManager.LoadScene("Extra");
                break;
        }

    }
}
