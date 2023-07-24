using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // 추후 싱글톤으로 업데이트 예정. static은 inspector view에는 안보임
    public Player player;

    private void Awake()
    {
        Instance = this;   
    }

}
