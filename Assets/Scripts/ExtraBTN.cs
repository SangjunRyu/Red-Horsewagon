using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ExtraBTN : MonoBehaviour
{
    public pageBTN btn;
    public ExtraTextHandler handler;

    private void Awake()
    {
        
    }
    
    public void OnBTNClick()
    {
        switch (btn)
        {

            case pageBTN.previous:
                handler.ShowPreviousPage();
                break;

            case pageBTN.next:
                handler.ShowNextPage();
                break;

            default:
                break;
        }
    }
}
