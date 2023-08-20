using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//�����
[System.Serializable]
public class Effect
{
    public AudioClip clip; //����� effect ����
    public AudioSource source; //effect������ ��������ִ� ������ ������Ʈ
}

public class ClearHill_last : MonoBehaviour
{
    public Image dialogue_UI; //���â
    [SerializeField] private Text dialogue_txt; //���â ���
    [SerializeField] private Text redhorsegon; //
    [SerializeField] private Dialogue[] dialogue; //��� ����Ʈ
    [SerializeField] public Effect[] effectSounds; //����� ����Ʈ
    public Image Ending; //����ȭ��
    public Image Dark;

    private int count = 0; //��� ����
    
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

        Dark.gameObject.SetActive(false);
        dialogue_UI.gameObject.SetActive(false);
        effectSounds[0].source.loop = true;
        effectSounds[0].source.Play(); //���μҸ� ����

        PlayerPrefs.SetInt("GameCleared", 1); // ���� Ŭ���� ��Ȳ����. ���� Extra ��ư Ȱ��ȭ�˻��
        PlayerPrefs.Save();
        Debug.Log("gameCleared");

        StartCoroutine(Text_Show());
    }

    IEnumerator Text_Show()
    {
        yield return new WaitForSeconds(3);

        //���â Ȱ��ȭ
        dialogue_UI.gameObject.SetActive(true);

        //**���â ��� ���
        while (count <4)
        {
            if (count == 2) //����° �������
                effectSounds[0].source.Stop(); //���μҸ� ����
            
            dialogue_txt.text = dialogue[count].dialogue;
            dialogue_txt.gameObject.SetActive(true);
            yield return new WaitForSeconds(2);

            if (count != 3) //������ ���簡 �ƴ϶�� ���� ���� ����
            {
                dialogue_txt.gameObject.SetActive(false);
                yield return new WaitForSeconds(0.5f);
            }
            count++;
        }

        //���â ��Ȱ��ȭ
        dialogue_UI.gameObject.SetActive(false);
        yield return new WaitForSeconds(1f);
        Dark.gameObject.SetActive(true);

        //**���Ҹ� ���
        effectSounds[1].source.loop = false;
        effectSounds[1].source.Play();
        yield return new WaitForSeconds(8);

        //**��� ��� ���
        while (count < 7)
        {
            redhorsegon.text = dialogue[count].dialogue; //��� ���
            redhorsegon.gameObject.SetActive(true);
            yield return new WaitForSeconds(2.5f);

            redhorsegon.gameObject.SetActive(false);
            yield return new WaitForSeconds(0.5f);
            count++;
        }
        yield return new WaitForSeconds(1.5f);

        //**�� �� �Ϸ���Ʈ Ȱ��ȭ
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
