using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum pageBTN // 2가지 타입 버튼 정의
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
        texts[0].gameObject.SetActive(true);    // 처음 Extra 씬 진입 시 맨 처음 대사창 출력
        currentPage= 0;
    }

    public void ShowPreviousPage()
    {
        if (currentPage == 0)
        {
            SceneManager.LoadScene("Main"); // 처음 대본에서 이전 누를 시에 Main씬으로 돌아감
            return;
        }

        texts[currentPage].gameObject.SetActive(false);
        currentPage--;
        texts[currentPage].gameObject.SetActive(true);  // 이전 페이지를 출력
    }

    public void ShowNextPage()
    {
        if (currentPage == texts.Length-1)
        {
            SceneManager.LoadScene("Main");     // 마지막 대사에서 다음 누를 시 메인으로 돌아감
            return;
        }
        texts[currentPage].gameObject.SetActive(false);
        currentPage++;
        texts[currentPage].gameObject.SetActive(true);
    }
}
