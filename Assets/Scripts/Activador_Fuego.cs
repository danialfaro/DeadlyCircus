using UnityEngine;

public class Activador_Fuego : MonoBehaviour
{
    public ParticleSystem firePS;
    public Animator animator;
    public AudioSource fire_SXF;
    private bool activado = false;

    GameObject personaje;

    // Start is called before the first frame update
    void Start()
    {
        personaje = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

        if (Mathf.Abs(personaje.transform.position.x - this.transform.position.x) <= 3f && Mathf.Abs(personaje.transform.position.y - this.transform.position.y) <= 3f)
        {
            animator.SetTrigger("Cerca");
            if (!firePS.isPlaying) firePS.Play();
            if(!activado)
            {
                fire_SXF.Play();
                activado = true;
            }
            
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
            }
        }
    }
}
