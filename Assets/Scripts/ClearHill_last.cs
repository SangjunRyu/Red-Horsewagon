using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//오디오
[System.Serializable]
public class Effect
{
    public AudioClip clip; //재생할 effect 파일
    public AudioSource source; //effect파일을 재생시켜주는 별도의 컴포넌트
}

public class ClearHill_last : MonoBehaviour
{
    [SerializeField] private Text txt_Dialogue;
    [SerializeField] private Dialogue[] dialogue; //대사 리스트
    [SerializeField] public Effect[] effectSounds; //오디오 리스트
    public Image Ending; //엔딩화면

    private int count = 0; //대사 갯수
    private int corout = 0; //현재 반복 횟수
    
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

        effectSounds[0].source.loop = true;
        effectSounds[0].source.Play(); //구두소리 실행
    }

    void Update()
    {
        if (corout == 0)
        {
            StartCoroutine(Text_Show());
            corout++;
        }
    }

    IEnumerator Text_Show()
    {
        yield return new WaitForSeconds(3);
        effectSounds[1].source.Play(); //노랫소리 실행

        while (count <4)
        {
            if (count == 2)
                effectSounds[0].source.Stop(); //구두소리 중지
            
            txt_Dialogue.text = dialogue[count].dialogue;
            txt_Dialogue.gameObject.SetActive(true);
            yield return new WaitForSeconds(2);

            txt_Dialogue.gameObject.SetActive(false);
            yield return new WaitForSeconds(0.3f);
            count++;
        }

        effectSounds[1].source.Stop();
        txt_Dialogue.text = dialogue[count].dialogue;
        txt_Dialogue.color = Color.red;
        txt_Dialogue.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);

        effectSounds[2].source.loop = false;
        effectSounds[2].source.Play();

        yield return new WaitForSeconds(2f);

        Ending.gameObject.SetActive(true);
        Debug.Log("끝");

    }
}
