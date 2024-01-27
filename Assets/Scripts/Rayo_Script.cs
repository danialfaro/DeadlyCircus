using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Rayo_Script : MonoBehaviour
{
    public GameObject player;
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
        Debug.Log("Colision");
        if(collision.tag.Equals("Player"))
        {
            Debug.Log("Me dio el Rayo");
            //Game Over
        }
        
    }
}
