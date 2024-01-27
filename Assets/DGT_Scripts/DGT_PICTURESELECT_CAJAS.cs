using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DGT_PICTURESELECT_CAJAS : MonoBehaviour
{
    public bool isTrigger=false;
    public bool correctAnswer=false;
    public MinijuegoController_Cajas minijuegoController_Cajas;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)&&isTrigger)
        {
            Debug.Log("Intercat");
            if (correctAnswer)
            {
                Debug.Log("Acertaste");
                minijuegoController_Cajas.PruebaSuperada();
                
            }
            else
            {
                Debug.Log("fallaste");
                minijuegoController_Cajas.PruebaFallida();
                
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
