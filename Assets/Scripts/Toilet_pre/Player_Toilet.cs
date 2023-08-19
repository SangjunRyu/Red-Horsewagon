using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player_Toilet : MonoBehaviour
{
    public Vector2 inputVec;
    public float speed = 5;
    private bool isMove = true;      // Ư�� ��ֹ� ���� �� ����
    public Rigidbody2D rigid;

    private AudioSource audioSource;     // �ȱ� ����

    public Image dialogue_UI; //���â UI
    public Text dialogue_right; //�´� �� ���
    public Text dialogue_wrong; //Ʋ�� �� ���

    public Image txt_screen;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        dialogue_UI.gameObject.SetActive(false); //���â ��Ȱ��ȭ
        txt_screen.gameObject.SetActive(false); //���� ���� ȭ�� ��Ȱ��ȭ
    }

    // Start is called before the first frame update
    void Update() // �� �����Ӹ��� ȣ��. �ܼ��� Ű �Է�, Ÿ�̸ӿ� �ַ� ���
    {
        if (isMove)
        {
            inputVec.x = Input.GetAxisRaw("Horizontal");
            inputVec.y = Input.GetAxisRaw("Vertical");
            
        }
        // x�� (a,d,�¿�Ű�� �̵�)  raw�� �� ������ ��Ʈ��
        //y�൵ ���� ������� ����� �ش�

    }

    private void FixedUpdate()  // fixed timestep���� ȣ��. ����ȿ�� ����� ������Ʈ�� ���
    {
        Vector2 nextVec = inputVec.normalized * speed * Time.fixedDeltaTime;  // ũ�� ����ȭ. �׳� deltatime�� update����
        rigid.MovePosition(rigid.position + nextVec);


        if (nextVec.x != 0 || nextVec.y != 0) //ĳ������ �̵����� 0�� �ƴ϶��
        {
            if (!audioSource.isPlaying) //������� ����ǰ� ���� �ʴٸ�
                audioSource.Play(); //����� ���
        }
        else
            audioSource.Stop(); //�̵����� 0�̸� ����� �ߴ�
    }

    private void OnTriggerEnter2D(Collider2D collision) //���� �浹�� ��
    {
        Debug.Log("Door!");
        audioSource.Stop();
        dialogue_UI.gameObject.SetActive(true); //���â Ȱ��ȭ
;
        if (collision.gameObject.CompareTag("Rightdoor")) //�ùٸ� �� �� ��
            StartCoroutine(Right());
        else
            StartCoroutine(Wrong());

    }
    IEnumerator Right()
    {
        dialogue_wrong.gameObject.SetActive(false); //Ʋ������ ��� ��Ȱ��ȭ
        dialogue_right.gameObject.SetActive(true);;//�¾����� ��� Ȱ��ȭ
        speed = 0; //ĳ���� ���� ���ϵ���
        yield return new WaitForSeconds(1f);
        txt_screen.gameObject.SetActive(true); //���� ���� ȭ�� Ȱ��ȭ
        dialogue_UI.gameObject.SetActive(false);
    }

    IEnumerator Wrong() //��� ĳ���� ����
    {
        dialogue_right.gameObject.SetActive(false);
        speed = 0;
        yield return new WaitForSeconds(1f);
        speed = 5;
        dialogue_UI.gameObject.SetActive(false);
    }
}
