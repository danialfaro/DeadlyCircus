using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IniciadorTransicion : MonoBehaviour
{
    public Animator transicion_Animator;

    // Start is called before the first frame update
    void Start()
    {
        transicion_Animator.SetTrigger("Entrar");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
