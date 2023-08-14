using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour, IObstacle
{
    public float speed= 5f;
    public float decel, stopsec;
    
    private void Awake()
    {

    }

    private void Update()
    {
        Vector3 curPos = transform.position;                        // ��� �����̱�
        Vector3 nextPos = Vector3.down * speed * Time.deltaTime;
        transform.position = curPos + nextPos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Border")
        {
            Destroy(gameObject);
        }
    }

    public void CollisionEffect(Player player)
    {
        player.SlowDown(decel);                 // ����
        StartCoroutine(player.Stop(stopsec));   // �����ð� ����
    }
}
