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
    
    private AudioSource audioSource;     // �ȱ� ����
    private float initialPitch = 1.25f; // ���� ���� ����
    private float minPitch = 0.25f;     // �ӵ��� �پ��� �� ���� ������

    private void Awake()
    {
        rigid= GetComponent<Rigidbody2D>();
        audioSource= GetComponent<AudioSource>();
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

}
