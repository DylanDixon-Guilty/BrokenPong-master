using System.Collections.Generic;
using UnityEditor.U2D.Aseprite;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private enum ColisionTag
    {
        ScoreWall,
        BounceWall,
        Player
    }

    [SerializeField] private float speed = 8f;
    [SerializeField] private List<string> tags;
    private Vector2 moveDirection;

    [SerializeField] private AudioSource audioManager;
    [SerializeField] private AudioClip pongPlayerCollide;
    [SerializeField] private AudioClip pongWallCollide;
    [SerializeField] private AudioClip pongScore;
    void Start()
    {
        transform.position = Vector2.zero;
        moveDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }

    void Update()
    {
        transform.Translate(moveDirection * speed * Time.deltaTime);
    }

    /// <summary>
    /// When the ball hits either Player's 1 or Player's 2 goal, the ball will reset to 0, 0, 0 and send the ball into a random direction.
    /// </summary>
    private void ResetBall()
    {
        transform.position = Vector2.zero;
        moveDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(tags[(int)ColisionTag.ScoreWall]))
        {
            ResetBall();
            GameManager.IncrementScore(other.GetComponent<ScoreWall>().ScoringPlayer);
        }
        else if (other.CompareTag(tags[(int)ColisionTag.BounceWall]))
        {
            moveDirection.y = -moveDirection.y;
        }
        else if (other.CompareTag(tags[(int)ColisionTag.Player]))
        {
            moveDirection.x = -moveDirection.x;
            moveDirection.y = transform.position.y - other.transform.position.y;
            moveDirection = moveDirection.normalized;
        }
    }
}
