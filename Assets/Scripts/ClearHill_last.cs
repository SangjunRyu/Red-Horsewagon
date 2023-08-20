using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ClearHill_last : MonoBehaviour
{
<<<<<<< Updated upstream
    [SerializeField] private Text txt_Dialogue;
    [SerializeField] private Dialogue[] dialogue;

    private int count = 0;
    private int corout = 0;
    public Image islast;

    void Update()
    {
        if (islast.gameObject.activeSelf == true)
        {
            if (corout == 0)
            {
                StartCoroutine(Text_Show(1));
                corout++;
                Debug.Log("�ణ����");
            }
        }
=======
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

<<<<<<< HEAD
        
    }
=======
        PlayerPrefs.SetInt("GameCleared", 1); // ���� Ŭ���� ��Ȳ����. ���� Extra ��ư Ȱ��ȭ�˻��
        PlayerPrefs.Save();
        Debug.Log("gameCleared");
>>>>>>> 024689d8a617d0631faa834efecb7f5aa5a815aa

        StartCoroutine(Text_Show());
>>>>>>> Stashed changes
    }

    IEnumerator Text_Show(float time)
    {
<<<<<<< Updated upstream
        yield return new WaitForSeconds(time);
        while (count <3)
        {
            Debug.Log("�𼺰�");
            txt_Dialogue.text = dialogue[count].dialogue;
            txt_Dialogue.gameObject.SetActive(true);
            yield return new WaitForSeconds(time);
            txt_Dialogue.gameObject.SetActive(false);
            yield return new WaitForSeconds(0.5f);
            count++;
        }
        txt_Dialogue.text = dialogue[count].dialogue;
        txt_Dialogue.color = Color.red;
        txt_Dialogue.gameObject.SetActive(true);
=======
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
        yield return new WaitForSeconds(4);

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

<<<<<<< HEAD
        PlayerPrefs.SetInt("GameCleared", 1); // ���� Ŭ���� ��Ȳ����. ���� Extra ��ư Ȱ��ȭ�˻��
        PlayerPrefs.Save();
        Debug.Log("gameCleared");
        Ending.gameObject.SetActive(true);
        Debug.Log("��");
=======
        yield return new WaitForSeconds(3);
>>>>>>> 024689d8a617d0631faa834efecb7f5aa5a815aa
>>>>>>> Stashed changes

        SceneManager.LoadScene("Main");
    }
}
