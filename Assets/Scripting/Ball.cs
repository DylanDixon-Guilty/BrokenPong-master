using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private enum ColisionTag
    {
        ScoreWallLeft,
        ScoreWallRight,
        BounceWall,
        Player
    }

    [SerializeField] private float speed = 8f;
    [SerializeField] private List<string> scoreWallTag;
    private Vector2 moveDirection;

    [SerializeField] private AudioSource aS;
    [SerializeField] private AudioClip clip1;
    [SerializeField] private AudioClip clip2;
    [SerializeField] private AudioClip clip3;
    void Start()
    {
        transform.position = Vector2.zero;
        moveDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }

    void Update()
    {
        transform.Translate(moveDirection * speed * Time.deltaTime);
    }

    private void ResetBall()
    {
        transform.position = Vector2.zero;
        moveDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(tags[0]))
        {
            ResetBall();
        }
        else if (other.CompareTag(otherTag))
        {
            moveDirection.y = -moveDirection.y;
        }
        else if (other.CompareTag("Player"))
        {
            moveDirection.x = -moveDirection.x;
            moveDirection.y = transform.position.y - other.transform.position.y;
            moveDirection = moveDirection.normalized;
        }
    }
}
