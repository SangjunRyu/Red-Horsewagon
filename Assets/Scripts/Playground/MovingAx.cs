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
        transform.Rotate(Vector3.back * Time.deltaTime * 360);
    }
}
