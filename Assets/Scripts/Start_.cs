using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[System.Serializable]

public class Dialogue
{
    [TextArea]
    public string dialogue; //대사 입력

}

public class Start_ : MonoBehaviour
{
    [SerializeField] private Text txt_Dialogue; //첫번째 줄
    [SerializeField] private Text txt_Dialogue_second; //두번째 줄
    [SerializeField] private Text txt_Dialogue_third; //세번째 줄

    [SerializeField] private Dialogue[] dialogue; //대사묶음

    private int count = 0; //현재 대사 출력 횟수
    private int count1 = 0; //첫번째 줄에 넣을 대사
    private int count2 = 0; //두번째 줄 " "
    private int count3 = 0; //세번째 줄 " "

    
    public int NextDialogue(Text txt, int cnt)
    {
        
        txt.text = dialogue[cnt].dialogue; //텍스트 변경
        if (cnt % 2 == 0)
            txt.color = Color.red; //짝수번째 대사라면 빨간색
        else
            txt.color = Color.white; //홀수번째 대사라면 하얀색
        cnt++; //현재 대사 출력 횟수 증가

        return cnt; //현재 대사 출력 횟수 반환
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //마우스 클릭
        {
            if (count < 8) //현재 대사 출력 횟수가 8번보다 작다면
            {
                count1 = NextDialogue(txt_Dialogue, count1); //첫번째 줄 대사 변경
                if (count > 0) //대사 출력 횟수가 0번 초과라면
                    count2=NextDialogue(txt_Dialogue_second, count2); //두번째 줄도 대사 변경
                if (count > 1) //대사 출력 횟수가 1번 초과라면
                    count3=NextDialogue(txt_Dialogue_third, count3); //세번째 줄도 대사 변경
            }
            else //대사 출력 횟수가 8번 이상이라면 씬 이동
                SceneManager.LoadScene("Toilet");

            count++; //대사 출력 횟수 증가
        }
    }
}
