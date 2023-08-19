using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player_Toilet : MonoBehaviour
{
    public Vector2 inputVec;
    public float speed = 5;
    private bool isMove = true;      // 특정 장애물 닿을 시 정지
    public Rigidbody2D rigid;

    private AudioSource audioSource;     // 걷기 사운드

    public Image dialogue_UI; //대사창 UI
    public Text dialogue_right; //맞는 문 대사
    public Text dialogue_wrong; //틀린 문 대사

    public Image txt_screen;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        dialogue_UI.gameObject.SetActive(false); //대사창 비활성화
        txt_screen.gameObject.SetActive(false); //글자 연출 화면 비활성화
    }

    // Start is called before the first frame update
    void Update() // 매 프레임마다 호출. 단순한 키 입력, 타이머에 주로 사용
    {
        if (isMove)
        {
            inputVec.x = Input.GetAxisRaw("Horizontal");
            inputVec.y = Input.GetAxisRaw("Vertical");
            
        }
        // x축 (a,d,좌우키로 이동)  raw로 더 섬세한 컨트롤
        //y축도 같은 방식으로 만들어 준다

    }

    private void FixedUpdate()  // fixed timestep마다 호출. 물리효과 적용된 오브젝트에 사용
    {
        Vector2 nextVec = inputVec.normalized * speed * Time.fixedDeltaTime;  // 크기 정규화. 그냥 deltatime은 update에서
        rigid.MovePosition(rigid.position + nextVec);


        if (nextVec.x != 0 || nextVec.y != 0) //캐릭터의 이동값이 0이 아니라면
        {
            if (!audioSource.isPlaying) //오디오가 재생되고 있지 않다면
                audioSource.Play(); //오디오 재생
        }
        else
            audioSource.Stop(); //이동값이 0이면 오디오 중단
    }

    private void OnTriggerEnter2D(Collider2D collision) //문과 충돌할 때
    {
        Debug.Log("Door!");
        audioSource.Stop();
        dialogue_UI.gameObject.SetActive(true); //대사창 활성화
;
        if (collision.gameObject.CompareTag("Rightdoor")) //올바른 문 일 때
            StartCoroutine(Right());
        else
            StartCoroutine(Wrong());

    }
    IEnumerator Right()
    {
        dialogue_wrong.gameObject.SetActive(false); //틀렸을때 대사 비활성화
        dialogue_right.gameObject.SetActive(true);;//맞았을때 대사 활성화
        speed = 0; //캐릭터 조작 못하도록
        yield return new WaitForSeconds(1f);
        txt_screen.gameObject.SetActive(true); //글자 연출 화면 활성화
        dialogue_UI.gameObject.SetActive(false);
    }

    IEnumerator Wrong() //잠시 캐릭터 멈춤
    {
        dialogue_right.gameObject.SetActive(false);
        speed = 0;
        yield return new WaitForSeconds(1f);
        speed = 5;
        dialogue_UI.gameObject.SetActive(false);
    }
}
