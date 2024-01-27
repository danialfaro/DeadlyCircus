using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    // Añade un nuevo campo para almacenar la posición actual del personaje
    public Vector2 currentCheckpointPosition;

    public bool Pepe_Vivo;
    [SerializeField]
    private GameObject personaje;
    [SerializeField]
    private Animator transicion_Animator;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

            // Buscar el gameobject con tag personaje
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Start()
    {
        transicion_Animator = GameObject.FindGameObjectWithTag("Transicion").GetComponent<Animator>();
        personaje = GameObject.FindGameObjectWithTag("Player");
    }

    public void SetCheckpoint(Vector2 checkpointPosition)
    {
        currentCheckpointPosition = checkpointPosition;
    }

    public void Morir()
    {
        Pepe_Vivo = false;
        personaje.GetComponent<Animator>().SetBool("Muerto", true);
        StartCoroutine(Reinicio());
    }

    IEnumerator Reinicio()
    {
        yield return new WaitForSeconds(1f);

        transicion_Animator = GameObject.FindGameObjectWithTag("Transicion").GetComponent<Animator>();
        transicion_Animator.SetTrigger("Salir");

        yield return new WaitForSeconds(1.5f);

        // Al reiniciar, carga la escena y luego ajusta la posición del personaje al último checkpoint
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);

        yield return new WaitForSeconds(1f);

        personaje = GameObject.FindGameObjectWithTag("Player");
        personaje.transform.position = currentCheckpointPosition;

        // Reinicia cualquier otro estado necesario (por ejemplo, animaciones, variables)
        personaje.GetComponent<Animator>().SetBool("Muerto", false);
        Pepe_Vivo = true;
    }
}
