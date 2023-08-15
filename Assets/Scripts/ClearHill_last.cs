using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearHill_last : MonoBehaviour
{
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
                Debug.Log("약간성공");
            }
        }
    }

    IEnumerator Text_Show(float time)
    {
        yield return new WaitForSeconds(time);
        while (count <3)
        {
            Debug.Log("찐성공");
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

    }
}
