using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Vector2 inputVec;
    public float speed=5;           // 이동속도, 장애물 닿을 시 감소. 1 도달시에 사망
    private bool isMove = true;      // 특정 장애물 닿을 시 정지
    public Rigidbody2D rigid;       
    
    private AudioSource audioSource;     // 걷기 사운드
    private float initialPitch = 1.25f; // 시작 사운드 높이
    private float minPitch = 0.25f;     // 속도가 줄었을 때 사운드 느리게

    private void Awake()
    {
        rigid= GetComponent<Rigidbody2D>();
        audioSource= GetComponent<AudioSource>();
    }

    void Update() // 매 프레임마다 호출. 단순한 키 입력, 타이머에 주로 사용
    {
        if(isMove)
            inputVec.x = Input.GetAxisRaw("Horizontal");   // x축 (a,d,좌우키로 이동)  raw로 더 섬세한 컨트롤
    }

    private void FixedUpdate()  // fixed timestep마다 호출. 물리효과 적용된 오브젝트에 사용
    {
        Vector2 nextVec = inputVec.normalized * speed * Time.fixedDeltaTime;  // 크기 정규화. 그냥 deltatime은 update에서
        rigid.MovePosition(rigid.position + nextVec);
    }

    public void SlowDown(float decel)
    {
        speed = speed - decel;
        audioSource.pitch -= 0.25f;
        if(speed <= 1)
        {
            GameManager.Instance.OnPlayerDead();
        }
    }

    public IEnumerator Stop(float stopsec)
    {
        isMove = false;
        yield return new WaitForSeconds(stopsec);   //0초 혹은 0.5초정도로 일단 설정
        isMove= true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IObstacle obstacle = collision.GetComponent<IObstacle>();
        if(obstacle != null)
        {
            obstacle.CollisionEffect(this);
        }
    }

}
