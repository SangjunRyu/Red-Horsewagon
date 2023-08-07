using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Vector2 inputVec;
    public float speed=5;

    public Rigidbody2D rigid;

    public string objectTag;

    private void Awake()
    {
        rigid= GetComponent<Rigidbody2D>();
    }

    void Update() // 매 프레임마다 호출. 단순한 키 입력, 타이머에 주로 사용
    {
        inputVec.x = Input.GetAxisRaw("Horizontal");   // x축 (a,d,좌우키로 이동)  raw로 더 섬세한 컨트롤
        //inputVec.y = Input.GetAxisRaw("Vertical");     // y축 (w,s,상하키로 이동)  
    }

    private void FixedUpdate()  // fixed timestep마다 호출. 물리효과 적용된 오브젝트에 사용
    {
        // 움직임 => addforce / ctrl velocity / moveposition
         
        Vector2 nextVec = inputVec.normalized * speed * Time.fixedDeltaTime;  // 크기 정규화. 그냥 deltatime은 update에서
        rigid.MovePosition(rigid.position + nextVec);
    }
 
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("MovingAx"))   // 날아오는 도끼 맞으면 한방컷
            SceneManager.LoadScene("Die");

        speed = speed - 1f;

        if (speed <= 1)
        {
            SceneManager.LoadScene("Die");
        }

    }

}
