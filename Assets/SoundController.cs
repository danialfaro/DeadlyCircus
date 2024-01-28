using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioClip gameOverClip;
    public AudioClip[] laughClips;

    AudioSource audioSourceMain;
    AudioSource audioSourceLaugh;

    private void Start()
    {
        audioSourceMain = GetComponents<AudioSource>()[0];
        audioSourceLaugh = GetComponents<AudioSource>()[1];
    }
    public void PlayGameOver()
    {
        audioSourceMain.clip = gameOverClip;
        audioSourceLaugh.clip = laughClips[Random.Range(0, laughClips.Length)];

        audioSourceLaugh.Play();
        audioSourceMain.Play();
    }
}
