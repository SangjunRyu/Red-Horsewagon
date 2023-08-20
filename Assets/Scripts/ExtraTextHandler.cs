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
        texts[0].gameObject.SetActive(true);    // 입장 시 첫 문단은 활성화
        currentPage = 0;
    }

    public void ShowPreviousPage()
    {
        if (currentPage == 0)
        {
            SceneManager.LoadScene("Main");    // 처음 페이지에서 이전 누를 시 메인으로
            return;
        }
        texts[currentPage].gameObject.SetActive(false);
        currentPage--;
        texts[currentPage].gameObject.SetActive(true);
    }

    public void ShowNextPage() {
        if (currentPage == texts.Length - 1) // 마지막 페이지일시
        {
            SceneManager.LoadScene("Main");
            return;
        }
        texts[currentPage].gameObject.SetActive(false);
        currentPage++;
        texts[currentPage].gameObject.SetActive(true);
    }

}
