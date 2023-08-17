using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour, IObstacle
{
    public float speed= 5f;
    public float decel, stopsec;
    public AudioSource audioSource;

    private void Awake()
    {
        audioSource= GetComponent<AudioSource>();
        audioSource.playOnAwake= false;
    }

    private void Update()
    {
        Vector3 curPos = transform.position;                        // 배경 움직이기
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
        audioSource.Play();                     // 장애물 소리
        player.SlowDown(decel);                 // 감속
        StartCoroutine(player.Stop(stopsec));   // 일정시간 정지
    }
}
