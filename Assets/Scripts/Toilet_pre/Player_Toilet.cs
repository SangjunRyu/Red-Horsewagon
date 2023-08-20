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
    public Text dialogue_txt; //���
    [SerializeField] private Dialogue[] dialogue; //��� ����

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
        speed = 0; //ĳ���� ���� ���ϵ���

        dialogue_txt.text = dialogue[1].dialogue;
        dialogue_txt.gameObject.SetActive(true);//��� Ȱ��ȭ
        yield return new WaitForSeconds(2);

        txt_screen.gameObject.SetActive(true); //���� ���� ȭ�� Ȱ��ȭ
    }

    IEnumerator Wrong() //��� ĳ���� ����
    {
        dialogue_txt.text = dialogue[0].dialogue; //Ʋ���� �� ����
        dialogue_txt.gameObject.SetActive(true); //��� Ȱ��ȭ
        speed = 0;
        yield return new WaitForSeconds(1f);
        speed = 5;
        dialogue_UI.gameObject.SetActive(false);
    }
}
