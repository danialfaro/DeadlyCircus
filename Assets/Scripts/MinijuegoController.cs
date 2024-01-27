using System.Collections;
using TMPro;
using UnityEngine;

public class MinijuegoController : MonoBehaviour
{
    public GameObject puertaInicio;
    public GameObject puertaSalida;
    public TMP_Text texto1;
    public TMP_Text texto2;
    public GameObject rayos;
    public GameObject carteles;
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

        yield return new WaitForSeconds(0.1f);
        puertaInicio.GetComponent<Animator>().SetTrigger("activado");
        puertaSalida.GetComponent<Animator>().SetTrigger("activado");
        texto1.enabled = true;
        yield return new WaitForSeconds(2f);
        carteles.SetActive(true);
        yield return new WaitForSeconds(2f);
        texto2.enabled = true;
        yield return new WaitForSeconds(35f);
        if (!pruebaSuperada)
        {
            rayos.SetActive(true);
        }
    }
    public void PruebaSuperada()
    {
        pruebaSuperada = true;
        puertaSalida.GetComponent<Animator>().SetTrigger("desactivado");
        texto1.enabled = false;
        texto2.enabled = false;
    }
}
