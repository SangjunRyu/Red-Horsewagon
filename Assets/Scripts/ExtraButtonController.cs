using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraButtonController : MonoBehaviour
{
    private void Awake()
    {
        if (!PlayerPrefs.HasKey("GameCleared")) // ������ Ŭ���� �� �� ��Ȳ�϶� ��Ȱ��ȭ
            gameObject.SetActive(false);
    }
}
