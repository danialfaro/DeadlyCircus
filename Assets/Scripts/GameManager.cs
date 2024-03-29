using System.Collections;
using TarodevController;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    SoundController soundController;

    public int contadorLuciernagas;
    public static GameManager Instance { get; private set; }

    public Vector2 currentCheckpointPosition;

    public bool Pepe_Vivo;

    public int checkpoint;
    [SerializeField]
    private GameObject personaje;
    [SerializeField]
    private Animator transicion_Animator;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

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

        soundController = GameObject.FindGameObjectWithTag("SoundController").GetComponent<SoundController>();

        transicion_Animator.gameObject.SetActive(true);

    }

    private void Update()
    {
        if (personaje.gameObject.transform.position.y < -15 && Pepe_Vivo)
        {
            Morir();
        }
    }

    public void SetCheckpoint(Vector2 checkpointPosition, int check)
    {
        if (check >= checkpoint)
        {
            currentCheckpointPosition = checkpointPosition;
            checkpoint = check;
        }
    }

    public void Morir()
    {
        personaje.GetComponent<PlayerController>().enabled = false;
        Pepe_Vivo = false;
        personaje.GetComponent<Animator>().SetBool("Muerto", true);
        contadorLuciernagas = 0;
        StartCoroutine(Reinicio());
    }

    IEnumerator Reinicio()
    {
        yield return new WaitForSeconds(1f);

        transicion_Animator = GameObject.FindGameObjectWithTag("Transicion").GetComponent<Animator>();
        transicion_Animator.SetTrigger("Salir");

        soundController = GameObject.FindGameObjectWithTag("SoundController").GetComponent<SoundController>();
        soundController.PlayGameOver();

        yield return new WaitForSeconds(2.2f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);

        yield return new WaitForSeconds(0.5f);

        personaje = GameObject.FindGameObjectWithTag("Player");
        personaje.transform.position = currentCheckpointPosition;

        personaje.GetComponent<Animator>().SetBool("Muerto", false);
        Pepe_Vivo = true;

        GameObject[] banderas = GameObject.FindGameObjectsWithTag("Checkpoints");
        foreach (GameObject bandera in banderas)
        {
            if (bandera.GetComponent<Checkpoints>().checkpoint < checkpoint)
            {
                bandera.GetComponent<Checkpoints>().Activar();
            }

        }
    }
}
