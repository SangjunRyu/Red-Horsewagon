using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//오디오
[System.Serializable]
public class Effect
{
    public AudioClip clip; //재생할 effect 파일
    public AudioSource source; //effect파일을 재생시켜주는 별도의 컴포넌트
}

public class ClearHill_last : MonoBehaviour
{
    public Image dialogue_UI; //대사창
    [SerializeField] private Text dialogue_txt; //대사창 대사
    [SerializeField] private Text redhorsegon; //
    [SerializeField] private Dialogue[] dialogue; //대사 리스트
    [SerializeField] public Effect[] effectSounds; //오디오 리스트
    public Image Ending; //엔딩화면
    public Image Dark;

    private int count = 0; //대사 갯수
    
    void Start()
    {
        for (int i = 0; i < effectSounds.Length; i++)
        {
            effectSounds[i].source = gameObject.AddComponent<AudioSource>();
            //effectSounds[i]변수에 오디오소스 파일 안에 있는 오디오 파일들을 불러줌
            effectSounds[i].source.clip = effectSounds[i].clip;
            //n개의 effectSounds.source.clip에 n개의 음악 파일을 넣어줌
            effectSounds[i].source.playOnAwake = false;
        }

        Dark.gameObject.SetActive(false);
        dialogue_UI.gameObject.SetActive(false);
        effectSounds[0].source.loop = true;
        effectSounds[0].source.Play(); //구두소리 실행

        PlayerPrefs.SetInt("GameCleared", 1); // 게임 클리어 상황저장. 메인 Extra 버튼 활성화검사용
        PlayerPrefs.Save();
        Debug.Log("gameCleared");

        StartCoroutine(Text_Show());
    }

    IEnumerator Text_Show()
    {
        yield return new WaitForSeconds(3);

        //대사창 활성화
        dialogue_UI.gameObject.SetActive(true);

        //**대사창 대사 출력
        while (count <4)
        {
            if (count == 2) //세번째 가사부터
                effectSounds[0].source.Stop(); //구두소리 중지
            
            dialogue_txt.text = dialogue[count].dialogue;
            dialogue_txt.gameObject.SetActive(true);
            yield return new WaitForSeconds(2);

            if (count != 3) //마지막 가사가 아니라면 가사 간의 공백
            {
                dialogue_txt.gameObject.SetActive(false);
                yield return new WaitForSeconds(0.5f);
            }
            count++;
        }

        //대사창 비활성화
        dialogue_UI.gameObject.SetActive(false);
        yield return new WaitForSeconds(1f);
        Dark.gameObject.SetActive(true);

        //**비명소리 출력
        effectSounds[1].source.loop = false;
        effectSounds[1].source.Play();
        yield return new WaitForSeconds(8);

        //**가운데 대사 출력
        while (count < 7)
        {
            redhorsegon.text = dialogue[count].dialogue; //대사 출력
            redhorsegon.gameObject.SetActive(true);
            yield return new WaitForSeconds(2.5f);

            redhorsegon.gameObject.SetActive(false);
            yield return new WaitForSeconds(0.5f);
            count++;
        }
        yield return new WaitForSeconds(1.5f);

        //**눈 뜬 일러스트 활성화
        Ending.gameObject.SetActive(true);
        effectSounds[2].source.loop = false;
        effectSounds[2].source.Play();
        yield return new WaitForSeconds(2);
        Ending.gameObject.SetActive(false);

        redhorsegon.text = dialogue[count].dialogue;
        redhorsegon.color = Color.red;
        redhorsegon.gameObject.SetActive(true);

        yield return new WaitForSeconds(3);

        SceneManager.LoadScene("Main");
    }
}
