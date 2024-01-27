using TarodevController;
using UnityEngine;

public class Activador_Fuego : MonoBehaviour
{
    public GameObject personaje;
    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(personaje.transform.position.x - this.transform.position.x) <= 2f)
        {
            animator.SetTrigger("Cerca");
            Debug.Log("Trigger activado");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (GameManager.Instance.Pepe_Vivo)
            {
                GameManager.Instance.Morir();
                personaje.GetComponent<PlayerController>().enabled = false;
            }
        }
    }
}
