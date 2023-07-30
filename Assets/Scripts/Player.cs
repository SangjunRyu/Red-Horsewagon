using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Vector2 inputVec;
    public float speed=5;

    Rigidbody2D rigid;

    private void Awake()
    {
        rigid= GetComponent<Rigidbody2D>();
    }

    void Update() // �� �����Ӹ��� ȣ��. �ܼ��� Ű �Է�, Ÿ�̸ӿ� �ַ� ���
    {
        inputVec.x = Input.GetAxisRaw("Horizontal");   // x�� (a,d,�¿�Ű�� �̵�)  raw�� �� ������ ��Ʈ��
        //inputVec.y = Input.GetAxisRaw("Vertical");     // y�� (w,s,����Ű�� �̵�)  
    }

    private void FixedUpdate()  // fixed timestep���� ȣ��. ����ȿ�� ����� ������Ʈ�� ���
    {
        // ������ => addforce / ctrl velocity / moveposition
         
        Vector2 nextVec = inputVec.normalized * speed * Time.fixedDeltaTime;  // ũ�� ����ȭ. �׳� deltatime�� update����
        rigid.MovePosition(rigid.position + nextVec);

    }
 
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("trigger");
        speed= speed - 1f;
        if (speed <= 0)
        {
            SceneManager.LoadScene("Die");
        }
                
    }

}
