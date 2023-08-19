using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//�����
[System.Serializable]
public class Effect
{
    public AudioClip clip; //����� effect ����
    public AudioSource source; //effect������ ��������ִ� ������ ������Ʈ
}

public class ClearHill_last : MonoBehaviour
{
    [SerializeField] private Text txt_Dialogue;
    [SerializeField] private Dialogue[] dialogue; //��� ����Ʈ
    [SerializeField] public Effect[] effectSounds; //����� ����Ʈ
    public Image Ending; //����ȭ��

    private int count = 0; //��� ����
    private int corout = 0; //���� �ݺ� Ƚ��
    
    void Start()
    {
        for (int i = 0; i < effectSounds.Length; i++)
        {
            effectSounds[i].source = gameObject.AddComponent<AudioSource>();
            //effectSounds[i]������ ������ҽ� ���� �ȿ� �ִ� ����� ���ϵ��� �ҷ���
            effectSounds[i].source.clip = effectSounds[i].clip;
            //n���� effectSounds.source.clip�� n���� ���� ������ �־���
            effectSounds[i].source.playOnAwake = false;
        }

        effectSounds[0].source.loop = true;
        effectSounds[0].source.Play(); //���μҸ� ����
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
        effectSounds[1].source.Play(); //�뷧�Ҹ� ����

        while (count <4)
        {
            if (count == 2)
                effectSounds[0].source.Stop(); //���μҸ� ����
            
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
        Debug.Log("��");

    }
}
