using System.Collections;
using System.Collections.Generic;
using TarodevController;
using Unity.VisualScripting;
using UnityEngine;

public class Rayo_Script : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Colision");
        if(collision.tag.Equals("Player"))
        {
            Debug.Log("Me dio el Rayo");
            if (GameManager.Instance.Pepe_Vivo)
            {
                GameManager.Instance.Morir();
            }
        }
        
    }
}
