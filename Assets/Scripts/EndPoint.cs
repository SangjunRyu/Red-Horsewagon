using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint : MonoBehaviour
{
    Playground playground = null;

    private void Awake()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Player player = other.GetComponent<Player>();

        if (player)
        {
            playground = GetComponentInParent<Playground>();
            playground.speed = 0f;
            Debug.Log("endpoint!");
        }
    }
}
