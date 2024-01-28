using UnityEngine;

public class Checkpoints : MonoBehaviour
{
    GameObject personaje;
    public Animator animator;
    public int checkpoint;
    public bool activado = false;

    private void Start()
    {
        personaje = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(personaje.transform.position.x - this.transform.position.x) <= 2f)
        {
            animator.SetTrigger("Cerca");
            Debug.Log("Trigger activado");
            if (!activado)
            {
                activado = true;

                Vector2 posicion = new Vector2(transform.position.x, transform.position.y + 1.4f);

                GameManager.Instance.SetCheckpoint(posicion, checkpoint);
            }
        }
    }

    public void Activar()
    {
        animator.SetTrigger("Cerca");
        activado = true;
    }
}
