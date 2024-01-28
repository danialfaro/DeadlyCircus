using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MinijuegoController_Cajas : MonoBehaviour
{
    public GameObject puertaInicio;
    public GameObject puertaSalida;
    public TMP_Text texto;
    public GameObject cajas;
    public bool pruebaSuperada;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            StartCoroutine(InicioMinijuego());
            Debug.Log("iniciando Pureba");
        }
    }
    IEnumerator InicioMinijuego()
    {
        texto.enabled = true;
        yield return new WaitForSeconds(0.1f);
        puertaInicio.GetComponent<Animator>().SetTrigger("activado");
        puertaSalida.GetComponent<Animator>().SetTrigger("activado");
        yield return new WaitForSeconds(39f);
        if (!pruebaSuperada)
        {
           PruebaFallida();
        }
    }
    public void PruebaSuperada()
    {
        pruebaSuperada = true;
        puertaSalida.GetComponent<Animator>().SetTrigger("desactivado");
        texto.enabled = false;
    }
    public void PruebaFallida()
    {
        cajas.SetActive(true);
        //perderJuego
    }
}
