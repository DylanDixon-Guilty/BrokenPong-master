using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float x = 8f;
    [SerializeField] private List<string> tags;
    [SerializeField] private string otherTag;
    private Vector2 v;

    [SerializeField] private AudioSource aS;
    [SerializeField] private AudioClip clip1;
    [SerializeField] private AudioClip clip2;
    [SerializeField] private AudioClip clip3;
    void Start()
    {
        transform.position = Vector2.zero;
        v = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }

    void Update()
    {
        transform.Translate(v * x * Time.deltaTime);
    }

    private void ResetBall()
    {
        transform.position = Vector2.zero;
        v = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(tags[0]))
        {
            ResetBall();
        }
        else if (other.CompareTag(otherTag))
        {
            v.y = -v.y;
        }
        else if (other.CompareTag("Player"))
        {
            v.x = -v.x;
            v.y = transform.position.y - other.transform.position.y;
            v = v.normalized;
        }
    }
}
