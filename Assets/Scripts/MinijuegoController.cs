using System.Collections;
using TMPro;
using UnityEngine;

public class MinijuegoController : MonoBehaviour
{
    public GameObject puertaInicio;
    public GameObject puertaSalida;
    public TMP_Text texto1;
    public TMP_Text texto2;
    public float velocidad = 0.01f;
    private string textoCompleto1 = "Llegaste a tu primer acertijo, espero que sepas resolverlo.";
    private string textoCompleto2 = "De dos nadas estoy hecho y simetrico soy.";
    private string textoCompleto3 = "Espero que elijas la opcion correcta...";
    public GameObject rayos;
    public GameObject carteles;
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
            soundM.clip=suspense_SFX;
            soundM.Play();
        }
    }
    IEnumerator InicioMinijuego()
    {
        puertaInicio.SetActive(true);
        puertaSalida.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        puertaInicio.GetComponent<Animator>().SetTrigger("activado");
        puertaSalida.GetComponent<Animator>().SetTrigger("activado");
        StartCoroutine(MostrarTextoLetraPorLetra(texto1, textoCompleto1));
        yield return new WaitForSeconds(5f);
        texto1.text = "";
        StartCoroutine(MostrarTextoLetraPorLetra(texto1, textoCompleto2));
        yield return new WaitForSeconds(5f);
        StartCoroutine(MostrarTextoLetraPorLetra(texto2, textoCompleto3));
        carteles.SetActive(true);

        yield return new WaitForSeconds(29f);
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
        soundM.clip = correct_SFX;
        soundM.Play();
        StartCoroutine(ReturnToMainMusic());
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
