using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toilet : MonoBehaviour
{
    private int SceneNum = 2;
    void Start()
    {
        PlayerPrefs.SetInt("SceneNum", SceneNum);
        PlayerPrefs.Save();

    }
}
