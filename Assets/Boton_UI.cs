using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Boton_UI : MonoBehaviour
{
    public TMP_Text text;
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
        if(collision.gameObject.tag == "Interactuable")
        {
            text.enabled = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Interactuable")
        {
            text.enabled = false;
        }
    }
}
