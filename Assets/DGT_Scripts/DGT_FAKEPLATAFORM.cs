using UnityEngine;

public class DGT_FAKEPLATAFORM : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb2D;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject, 10);
        }
    }
}
