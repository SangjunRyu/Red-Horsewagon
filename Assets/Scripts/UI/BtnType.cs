using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnType : MonoBehaviour
{
    public BTNType currentType;

    public void OnBtnClick()
    {
        switch(currentType)
        {
            case BTNType.New:
                SceneManager.LoadScene("Start"); //새로 시작이면 스타트 씬 이동
                break;

            case BTNType.Continue:
                {
                    if (!PlayerPrefs.HasKey("SceneNum"))
                        return;

                    int Scene = PlayerPrefs.GetInt("SceneNum");
                    
                    if (Scene==0)
                        SceneManager.LoadScene("Start");
                    else if (Scene == 1)
                        SceneManager.LoadScene("Toilet_pre");
                    else if (Scene == 2)
                        SceneManager.LoadScene("Toilet");
                    else if (Scene == 3)
                        SceneManager.LoadScene("Corridor");
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
        }

    }
}
