using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MinijuegoController_Cajas : MonoBehaviour
{
    public GameObject puertaInicio;
    public GameObject puertaSalida;
    public TMP_Text texto;
    public float velocidad = 0.05f;
    private string textoCompleto1 = "Felicidades Llegaste a tu segundo acertijo.";
    private string textoCompleto2 = "Adelante, juega con el juguete mas egoista.";
    public GameObject explosiones;
    public GameObject cajas;
    public bool pruebaSuperada;
    public AudioSource soundM;
    public AudioClip suspense_SFX;
    public AudioClip correct_SFX;
    public AudioClip playerMusic;
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
            GetComponent<BoxCollider2D>().enabled = false;
            soundM = GameObject.Find("SoundM").GetComponent<AudioSource>();
            soundM.clip = suspense_SFX;
            soundM.Play();
        }
    }
    IEnumerator InicioMinijuego()
    {
        texto.enabled = true;
        puertaInicio.SetActive(true);
        puertaSalida.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        puertaInicio.GetComponent<Animator>().SetTrigger("activado");
        puertaSalida.GetComponent<Animator>().SetTrigger("activado");
        StartCoroutine(MostrarTextoLetraPorLetra(texto, textoCompleto1));
        yield return new WaitForSeconds(5f);
        texto.text = "";
        StartCoroutine(MostrarTextoLetraPorLetra(texto, textoCompleto2));
        cajas.SetActive(true);
        yield return new WaitForSeconds(34f);
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
        soundM.clip = correct_SFX;
        soundM.Play();
        StartCoroutine(ReturnToMainMusic());
    }
    public void PruebaFallida()
    {
        explosiones.SetActive(true);
        //perderJuego
        if (GameManager.Instance.Pepe_Vivo)
        {
            GameManager.Instance.Morir();
        }
        cajas.SetActive(false);
    }
    IEnumerator MostrarTextoLetraPorLetra(TMP_Text texto, string textoCompleto)
    {
        int longitud = textoCompleto.Length;
        int indice = 0;

        while (indice < longitud)
        {
            texto.text += textoCompleto[indice];

            indice++;

            yield return new WaitForSeconds(velocidad);
        }
    }
    IEnumerator ReturnToMainMusic()
    {
        yield return new WaitForSeconds(3f);
        soundM.clip = playerMusic;
        soundM.Play();
    }
}
