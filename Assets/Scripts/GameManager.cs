using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Player player;
    public bool isGameover = false;
    public string gameScenes;       // set game stages. need to initialize 

    private void Awake()
    {
        if(Instance== null)     // Only one GameManager can exist in whole gameplay
        {
            Instance = this;
        }
        else
        {
            Debug.LogWarning("Two managers exist in one Scene!");
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if(isGameover)
        {
            SceneManager.LoadScene("Die");
        }
    }

    public void SceneUpdate()
    {

    }

    public void OnPlayerDead()      // called when player dies
    {
        gameScenes = SceneManager.GetActiveScene().name;    // save current scene's name
        isGameover = true;  // switch bool variable to load Die scene
    }
}
