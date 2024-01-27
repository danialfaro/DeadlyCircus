using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DGT_ROCK : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            DesstroyRock();
        }
        if (collision.gameObject.layer == 6)
        {
            DesstroyRock();
        }
    }
    public void DesstroyRock()
    {
        Destroy(gameObject);
    }
}
