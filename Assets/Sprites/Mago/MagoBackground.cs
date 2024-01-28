using UnityEngine;

public class MagoBackground : MonoBehaviour
{
    public GameObject player;
    public Animator animator;

    public float offset = 5f;

    float currentJokeTime = 5;

    void Update()
    {

        Vector3 posToFollow = new Vector3(player.transform.position.x, Mathf.Clamp(player.transform.position.y, -5, 20), 0);
        float distanceMultiplier = (transform.position - player.transform.position).magnitude * 0.2f;

        Vector3 smoothPosition = Vector3.Lerp(transform.position, posToFollow + new Vector3(offset, 0, 0), distanceMultiplier * Time.deltaTime);

        transform.position = smoothPosition;

        if (currentJokeTime <= 0)
        {
            currentJokeTime = Random.Range(6f, 10f);
            //play random joke
            int randomJoke = Jokes[Random.Range(0, Jokes.Length)];
            animator.Play(randomJoke);
        }

        currentJokeTime -= Time.deltaTime;

    }

    #region Animation Keys

    private static readonly int[] Jokes = { Animator.StringToHash("Joke01"), Animator.StringToHash("Joke02") };

    #endregion
}
