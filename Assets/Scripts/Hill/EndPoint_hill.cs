using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[System.Serializable]

public class EndPoint_hill : MonoBehaviour
{
    Hill Hill = null;

    //public Canvas dialogue_UI; //대사창 UI(캔버스)

    //[SerializeField] private Text txt_Dialogue; //대사가 들어갈 텍스트
    //[SerializeField] private Dialogue[] dialogue; //대사 묶음
    //0: 실패 대사 , 1: 성공 대사, 2: 맵 고유 대사

    //private bool isClear; //클리어 했는지
    //private bool map_dialogue; //맵 고유대사 출력 여부

    private void Awake()
    {
        //map_dialogue = false; //맵 고유대사 출력 여부 X
        gameObject.SetActive(false);
        //dialogue_UI.gameObject.SetActive(false); //대사창 UI 비활성화
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Player player = other.GetComponent<Player>();
        ItemQuest itemQuest = player.GetComponent<ItemQuest>();

        if (player)
        {
            Hill = GetComponentInParent<Hill>();
            Hill.speed = 0f;
            Debug.Log("endpoint!");
            player.GetComponent<AudioSource>().Stop();  // 걷기 사운드 끄기
        }

        if (itemQuest.isClear)
        {
            //isClear = true;
            Debug.Log("Clear!");    // 클리어. 다 찾음
            SceneManager.LoadScene("Clear_Hill"); //다음 씬으로
            //dialogue_UI.gameObject.SetActive(true); //대사창 활성화
            //txt_Dialogue.text = dialogue[1].dialogue; //성공 대사
        }
        else
        {
            Debug.Log("Fail!");     // 못찾음. 다시하기 씬
            GameManager.Instance.OnPlayerDead();

            //dialogue_UI.gameObject.SetActive(true); //대사창 활성화
            //txt_Dialogue.text = dialogue[0].dialogue; //실패 대사
        }
    }

    /*private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isClear) //클릭했을때 클리어 상태(조건 충족)
            {
                if (!map_dialogue) //성공했고 맵 고유대사 출력X
                {
                    txt_Dialogue.text = dialogue[2].dialogue;
                    map_dialogue = true;
                }
                else //성공했고 맵 고유대사 출력O
                    SceneManager.LoadScene("Clear_Hill"); //다음 씬으로
            }

            else //클릭했을때 조건미충족 상태
                GameManager.Instance.OnPlayerDead();
        }
    }*/
}
