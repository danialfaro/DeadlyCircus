using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DGT_ROCKDETECTOR : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb2D;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            rb2D.gravityScale = 1.0f;
        }
    }
}
