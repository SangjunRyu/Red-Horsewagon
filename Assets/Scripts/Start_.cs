using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[System.Serializable]

public class Dialogue
{
    [TextArea]
    public string dialogue; //��� �Է�

}

public class Start_ : MonoBehaviour
{
    [SerializeField] private Text txt_Dialogue; //ù��° ��
    [SerializeField] private Text txt_Dialogue_second; //�ι�° ��
    [SerializeField] private Text txt_Dialogue_third; //����° ��

    [SerializeField] private Dialogue[] dialogue; //��繭��

    private int count = 0; //���� ��� ��� Ƚ��
    private int count1 = 0; //ù��° �ٿ� ���� ���
    private int count2 = 0; //�ι�° �� " "
    private int count3 = 0; //����° �� " "

    
    public int NextDialogue(Text txt, int cnt)
    {
        
        txt.text = dialogue[cnt].dialogue; //�ؽ�Ʈ ����
        if (cnt % 2 == 0)
            txt.color = Color.red; //¦����° ����� ������
        else
            txt.color = Color.white; //Ȧ����° ����� �Ͼ��
        cnt++; //���� ��� ��� Ƚ�� ����

        return cnt; //���� ��� ��� Ƚ�� ��ȯ
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //���콺 Ŭ��
        {
            if (count < 8) //���� ��� ��� Ƚ���� 8������ �۴ٸ�
            {
                count1 = NextDialogue(txt_Dialogue, count1); //ù��° �� ��� ����
                if (count > 0) //��� ��� Ƚ���� 0�� �ʰ����
                    count2=NextDialogue(txt_Dialogue_second, count2); //�ι�° �ٵ� ��� ����
                if (count > 1) //��� ��� Ƚ���� 1�� �ʰ����
                    count3=NextDialogue(txt_Dialogue_third, count3); //����° �ٵ� ��� ����
            }
            else //��� ��� Ƚ���� 8�� �̻��̶�� �� �̵�
                SceneManager.LoadScene("Toilet");

            count++; //��� ��� Ƚ�� ����
        }
    }
}
