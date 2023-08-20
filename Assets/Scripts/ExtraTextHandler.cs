using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum pageBTN
{
    previous, next
}

public class ExtraTextHandler : MonoBehaviour
{
    public Text[] texts;
    public int totalPages;
    public int currentPage;

    private void Awake()
    {
        texts = GetComponentsInChildren<Text>();
        totalPages= texts.Length;
        foreach(Text text in texts)
        {
            text.gameObject.SetActive(false);
        }
        texts[0].gameObject.SetActive(true);    // ���� �� ù ������ Ȱ��ȭ
        currentPage = 0;
    }

    public void ShowPreviousPage()
    {
        if (currentPage == 0)
        {
            SceneManager.LoadScene("Main");    // ó�� ���������� ���� ���� �� ��������
            return;
        }
        texts[currentPage].gameObject.SetActive(false);
        currentPage--;
        texts[currentPage].gameObject.SetActive(true);
    }

    public void ShowNextPage() {
        if (currentPage == texts.Length - 1) // ������ �������Ͻ�
        {
            SceneManager.LoadScene("Main");
            return;
        }
        texts[currentPage].gameObject.SetActive(false);
        currentPage++;
        texts[currentPage].gameObject.SetActive(true);
    }

}
