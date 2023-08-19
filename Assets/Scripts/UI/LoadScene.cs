using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public AudioSource audioSource;

    void Awake()
    {
        audioSource= GetComponent<AudioSource>();
    }

    public void Retry()
    {
        audioSource.Play();
        Debug.Log("restart");
        GameManager.Instance.isGameover = false;
        SceneManager.LoadScene(GameManager.Instance.gameScenes);
    }

    public void Main() 
    {
        Debug.Log("main");
        SceneManager.LoadScene("Main");
    }

}
