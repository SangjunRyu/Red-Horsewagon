using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraButtonController : MonoBehaviour
{
    private void Awake()
    {
        if (!PlayerPrefs.HasKey("GameCleared")) // 게임이 클리어 안 된 상황일때 비활성화
            gameObject.SetActive(false);
    }
}
