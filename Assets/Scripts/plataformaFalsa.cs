using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plataformaFalsa : MonoBehaviour
{
    public bool jugadorEntra;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Player"))
        {
            jugadorEntra = true;
            gameObject.GetComponentInParent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            gameObject.GetComponentInParent<Rigidbody2D>().gravityScale = 10;
        }

    }
}
