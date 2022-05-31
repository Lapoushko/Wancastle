using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public Vector3 direction;
    private SpriteRenderer sprite;
    public Vector3 Direction { set { direction = value; } }
    private void Awake()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
        
    }
    public void Start()
    {
        Destroy(gameObject, 1.5f);
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.tag == "Enemy") || (other.tag == "Platform") || (other.tag == "Player") || (other.tag == "Land") || (other.tag == "blockWall") || (other.tag == "BOSS"))
        {
           Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if ((other.gameObject.tag == "Enemy") || (other.gameObject.tag == "Platform") || (other.gameObject.tag == "Player") || (other.gameObject.tag == "Land") || (other.gameObject.tag == "blockWall") || (other.gameObject.tag == "BOSS"))
        {
            Destroy(gameObject);
        }
    }
}
