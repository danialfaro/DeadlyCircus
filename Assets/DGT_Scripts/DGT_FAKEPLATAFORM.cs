using UnityEngine;

public class DGT_FAKEPLATAFORM : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb2D;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player hit");
            rb2D.gravityScale = 100;
            Destroy(this.gameObject, 1);
        }
    }
}
