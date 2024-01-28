using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sigue : MonoBehaviour
{
    public int count;
    // Start is called before the first frame update
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Firefly"))
        {
            Debug.Log("Han colisionado");
            transform.position = other.transform.position;
            other.transform.SetParent(this.transform);
            count ++;

            if (count == 3)
            {
                Debug.Log("Has muerto");
            }
        }

    }


    
}
