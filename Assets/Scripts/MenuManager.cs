using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Animator menu_Animator;
    public Animator transicion_Animator;
    public Animator jugador_Animator;

    public Button jugar;
    public Button opciones;
    public Button creditos;
    public Button salir;

    public GameObject menu;

    public void Jugar()
    {
        menu_Animator.SetTrigger("Jugar");

        jugar.interactable = false;
        opciones.interactable = false;
        creditos.interactable = false;
        salir.interactable = false;

        StartCoroutine(CambiarEscena());
    }

    public void Salir()
    {
        Application.Quit();
    }

    IEnumerator CambiarEscena()
    {
        yield return new WaitForSeconds(1.5f);
        jugador_Animator.SetBool("Muerto", true);
        yield return new WaitForSeconds(6f);

        transicion_Animator.SetTrigger("Salir");


        yield return new WaitForSeconds(0.5f);
        menu.SetActive(false);
        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
