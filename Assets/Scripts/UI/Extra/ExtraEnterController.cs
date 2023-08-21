using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraEnterController : MonoBehaviour
{

    private void Awake()
    {
        if(!PlayerPrefs.HasKey("GameCleared"))
            gameObject.SetActive(false);
    }
}
