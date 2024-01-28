using System.Collections;
using UnityEngine;

public class MagoFinal : MonoBehaviour
{

    public GameObject canvasCreditos;
    public AudioClip audioClipFinal;

    AudioSource audioSource;
    Animator animator;

    bool flagFinished = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        animator.Play("Final");
    }

    private void Update()
    {
        if (!flagFinished && !AnimatorIsPlaying())
        {
            flagFinished = true;
            print("anim finished");
            animator.enabled = false;

            audioSource.Pause();
            StartCoroutine(IniciarCreditos());
        }
    }

    bool AnimatorIsPlaying()
    {
        return 1 > animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
        //return animator.GetCurrentAnimatorStateInfo(0).length >
        //     animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
    }

    IEnumerator IniciarCreditos()
    {
        yield return new WaitForSeconds(1f);

        audioSource.clip = audioClipFinal;
        audioSource.Play();

        canvasCreditos.SetActive(true);
    }
}
