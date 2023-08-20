using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour, ISpeedChangeable
{
    public Vector2 inputVec;
    private float speed=5f;           // 이동속도, 장애물 닿을 시 감소. 1 도달시에 사망
    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }

    private bool isMove = true;      // 특정 장애물 닿을 시 정지
    public Rigidbody2D rigid;       
    
    public AudioSource audioSource1;     // 걷기 사운드
    public AudioSource audioSource2;     // 사망음악

    private void Awake()
    {
        rigid= GetComponent<Rigidbody2D>();
        
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
        if (speed > 1)
        {
            speed = speed - decel;
            audioSource1.pitch -= 0.25f;
            if (speed <= 1)
            {
                audioSource2.Play();                    // 비명소리 재생
                ISpeedChangeable speedChangeable = GetComponent<ISpeedChangeable>();
                SmoothSpeedChange speedChange = new SmoothSpeedChange();
                StartCoroutine(speedChange.SpeedChange(speedChangeable, speed));   // 속도 0까지 느려지다가 사망씬
                Invoke("DelayedPlayerDead", 2f);
            }
        }
    }

    private void DelayedPlayerDead()
    {
        GameManager.Instance.OnPlayerDead();
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

    public void ChangeSpeed(float targetSpeed, float duration) // 느려지는 효과를 위한 메서드
    {
        
    }    
}
