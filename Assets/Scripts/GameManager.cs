using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // ���� �̱������� ������Ʈ ����. static�� inspector view���� �Ⱥ���
    public Player player;

    private void Awake()
    {
        Instance = this;   
    }

}
