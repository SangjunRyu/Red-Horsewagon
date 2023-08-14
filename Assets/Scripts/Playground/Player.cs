using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Vector2 inputVec;
    public float speed=5;
    public bool isMove = true;
    public Rigidbody2D rigid;

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
        speed = speed - decel;
        if(speed <= 1)
        {
            GameManager.Instance.OnPlayerDead();
        }
    }
    public IEnumerator Stop(float stopsec)
    {
        isMove = false;
        yield return new WaitForSeconds(stopsec);
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
