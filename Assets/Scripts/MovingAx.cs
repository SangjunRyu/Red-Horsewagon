using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingAx : MonoBehaviour
{
    Rigidbody2D rigid;
    public float speed;
    Vector2 dirVec, norVec;

    private void Awake()
    {
        rigid= GetComponent<Rigidbody2D>();

    }

    void Start()
    {
        dirVec = GameManager.Instance.player.rigid.position - rigid.position;   // ∏Ò«• ∫§≈Õ
        norVec = dirVec.normalized;
    }

    private void Update()
    {
        rigid.velocity = norVec * Time.deltaTime * 2000;
        Debug.Log("rigid.vel" + rigid.velocity);
        transform.Rotate(Vector3.back * Time.deltaTime * 360);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Border")
        {
            Destroy(gameObject);
        }
    }
}
