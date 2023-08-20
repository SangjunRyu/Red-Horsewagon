using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour, ISpeedChangeable
{
    public Vector2 inputVec;
    private float speed=5f;           // �̵��ӵ�, ��ֹ� ���� �� ����. 1 ���޽ÿ� ���
    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }

    private bool isMove = true;      // Ư�� ��ֹ� ���� �� ����
    public Rigidbody2D rigid;       
    
    public AudioSource audioSource1;     // �ȱ� ����
    public AudioSource audioSource2;     // �������

    private void Awake()
    {
        rigid= GetComponent<Rigidbody2D>();
        
    }

    void Update() // �� �����Ӹ��� ȣ��. �ܼ��� Ű �Է�, Ÿ�̸ӿ� �ַ� ���
    {
        if(isMove)
            inputVec.x = Input.GetAxisRaw("Horizontal");   // x�� (a,d,�¿�Ű�� �̵�)  raw�� �� ������ ��Ʈ��
    }

    private void FixedUpdate()  // fixed timestep���� ȣ��. ����ȿ�� ����� ������Ʈ�� ���
    {
        Vector2 nextVec = inputVec.normalized * speed * Time.fixedDeltaTime;  // ũ�� ����ȭ. �׳� deltatime�� update����
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
                audioSource2.Play();                    // ���Ҹ� ���
                ISpeedChangeable speedChangeable = GetComponent<ISpeedChangeable>();
                SmoothSpeedChange speedChange = new SmoothSpeedChange();
                StartCoroutine(speedChange.SpeedChange(speedChangeable, speed));   // �ӵ� 0���� �������ٰ� �����
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
        yield return new WaitForSeconds(stopsec);   //0�� Ȥ�� 0.5�������� �ϴ� ����
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

    public void ChangeSpeed(float targetSpeed, float duration) // �������� ȿ���� ���� �޼���
    {
        
    }    
}
