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
                //Debug.Log("새 게임");
                SceneManager.LoadScene("Start"); //새로 시작이면 스타트 씬 이동
                break;

            case BTNType.Continue:
                //Debug.Log("이어 하기");
                //SceneManager.LoadScene("Load"); //이어하기면 로딩 씬 이동
                SceneManager.LoadScene("Playground");
                break;

            case BTNType.Quit:
                //Debug.Log("끝");
                Application.Quit();
                break;
        }

    }
}
