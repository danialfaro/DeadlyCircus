using UnityEngine;

public class ActiveJumpSFX : MonoBehaviour
{
    public AudioSource jumpSFX;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpSFX.Play();
        }
    }
}
