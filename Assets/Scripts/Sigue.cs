using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sigue : MonoBehaviour
{
    private float count;
    private void Update()
    {
        count = GameManager.Instance.contadorLuciernagas;
    }
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Han colisionado");
            transform.position = other.transform.position + new Vector3(count + Random.Range(-1f,-1.5f),count + Random.Range(1f, 1.5f),0);
            transform.SetParent(other.transform);
            GameManager.Instance.contadorLuciernagas++;

            if (GameManager.Instance.contadorLuciernagas >= 3)
            {
                Debug.Log("Has muerto");
                if (GameManager.Instance.Pepe_Vivo)
                {
                    GameManager.Instance.Morir();
                }
                GameManager.Instance.contadorLuciernagas = 0;
            }
        }

    }


    
}
