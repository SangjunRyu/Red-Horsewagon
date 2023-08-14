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
                //Debug.Log("�� ����");
                SceneManager.LoadScene("Start"); //���� �����̸� ��ŸƮ �� �̵�
                break;

            case BTNType.Continue:
                //Debug.Log("�̾� �ϱ�");
                //SceneManager.LoadScene("Load"); //�̾��ϱ�� �ε� �� �̵�
                SceneManager.LoadScene("Playground");
                break;

            case BTNType.Quit:
                //Debug.Log("��");
                Application.Quit();
                break;
        }

    }
}
