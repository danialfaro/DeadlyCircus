using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activarCohetes : MonoBehaviour
{
    public bool isTrigger = false;
    bool activado = false;
    public ParticleSystem cohetes;

    Animator fireworks_anim;

    private void Start()
    {
        fireworks_anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isTrigger)
        {
            activado = true;
            if (activado)
            {
                cohetes.Play();
                fireworks_anim.SetBool("Fire", true);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            isTrigger = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            isTrigger = false;
    }
}
