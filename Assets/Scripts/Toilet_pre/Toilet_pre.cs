using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toilet_pre : MonoBehaviour
{
    private int SceneNum = 1;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("SceneNum", SceneNum);
        PlayerPrefs.Save();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
