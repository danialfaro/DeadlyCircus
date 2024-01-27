using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DGT_PICTURESELECT : MonoBehaviour
{
    public bool isTrigger=false;
    public bool correctAnswer=false;
    public GameObject rayos;
    public GameObject puerta;
    public MinijuegoController minijuegoController;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)&&isTrigger)
        {
            Debug.Log("Intercat");
            if (correctAnswer)
            {
                Debug.Log("Acertaste");
                puerta.GetComponent<Animator>().SetTrigger("desactivado");
                minijuegoController.pruebaSuperada = true;
            }
            else
            {
                Debug.Log("fallaste");
                rayos.SetActive(true);
                
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
        if(collision.gameObject.tag=="Player")
        isTrigger= false;
    }
}
