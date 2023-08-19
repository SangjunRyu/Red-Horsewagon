using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Vector2 inputVec;
    public float speed=5;           // �̵��ӵ�, ��ֹ� ���� �� ����. 1 ���޽ÿ� ���
    private bool isMove = true;      // Ư�� ��ֹ� ���� �� ����
    public Rigidbody2D rigid;       
    
    public AudioSource audioSource1;     // �ȱ� ����
    public AudioSource audioSource2;     // �������
    //private float initialPitch = 1.25f; // ���� ���� ����
    //private float minPitch = 0.25f;     // �ӵ��� �پ��� �� ���� ������

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
                StartCoroutine(SmoothSpeedChange());    // ���� �������� ����� ����
            }
        }
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

    private IEnumerator SmoothSpeedChange()
    {
        float initialSpeed = 1.0f;
        float targetSpeed = 0f;
        float duration = 3f;

        float elapsedTime = 0.0f;
        float currentSpeed = initialSpeed;

        while (elapsedTime < duration)
        {
            currentSpeed = Mathf.Lerp(initialSpeed, targetSpeed, elapsedTime / duration); // 2�ʵ��� �ӵ����̱�
            speed = currentSpeed;
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        currentSpeed = targetSpeed;
        yield return new WaitForSeconds(0.5f);
        GameManager.Instance.OnPlayerDead();
    }


}
