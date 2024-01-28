using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sigue : MonoBehaviour
{
    public int count;
    // Start is called before the first frame update
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Han colisionado");
            transform.position = other.transform.position + new Vector3(Random.Range(-1f,-1.5f), Random.Range(1f, 1.5f),0);
            transform.SetParent(other.transform);
            count ++;

            if (count == 3)
            {
                Debug.Log("Has muerto");
            }
        }

    }


    
}
