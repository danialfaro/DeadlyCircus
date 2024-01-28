using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PelotaAsesina : MonoBehaviour
{
    Transform jugador; // Referencia al transform del jugador
    public GameObject pelota;
    public float velocidadSeguimiento = 5f; // Velocidad del objeto seguidor
    public float velocidadRotacion = 50f; // Velocidad de rotación constante



    // Start is called before the first frame update
    void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        if (jugador != null)
        {
            // Calcula la dirección hacia el jugador
            Vector3 direccion = jugador.position - transform.position;

            // Normaliza la dirección para obtener un vector de longitud 1
            direccion.Normalize();

            // Mueve el objeto seguidor hacia el jugador
            transform.Translate(direccion * velocidadSeguimiento * Time.deltaTime);

            // Rota constantemente en el eje Z
            pelota.transform.Rotate(Vector3.forward * velocidadRotacion * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (GameManager.Instance.Pepe_Vivo)
            {
                GameManager.Instance.Morir();
            }
        }
    }

}
