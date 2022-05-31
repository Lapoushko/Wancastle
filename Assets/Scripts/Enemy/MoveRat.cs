using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRat : MonoBehaviour
{
    public LayerMask maskPlayer;
    public float rayDistance;
    public bool RotRight;

    RaycastHit2D ray;
    Rigidbody2D rgb;
    //скорость енеми
    public float Speed = 6;
    //игрок
    public GameObject Person;
    public MovePlayer Player;
    public GameObject explosion;
    public int Health;
    public int DamageInRat;
    public Animator anim;

    void Awake()
    {
        rgb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        anim = GetComponent<Animator>();
        DamageInRat = Player.damage;
        if (RotRight == true) transform.localRotation = Quaternion.Euler(0, 180, 0); else transform.localRotation = Quaternion.Euler(0, 0, 0);
        Player = GetComponent<MovePlayer>();
    }

    void FixedUpdate()
    {
        Debug.DrawRay(transform.position, transform.right * rayDistance, Color.red);
        Debug.DrawRay(transform.position, transform.right * -rayDistance, Color.red);

        RaycastHit2D rayLeft = Physics2D.Raycast(transform.position, -transform.right, rayDistance, maskPlayer);
        RaycastHit2D rayRight = Physics2D.Raycast(transform.position, -transform.right, rayDistance, maskPlayer);

        if (rayRight.collider != null)
        {
            if (RotRight == true)
            {
                anim.SetBool("run", true);
                rgb.velocity = new Vector2(Speed, rgb.velocity.y);
                transform.localRotation = Quaternion.Euler(0, 180, 0);
               // Debug.Log("Right");
            }

        }
        if (rayLeft.collider != null)
        {
            if (RotRight == false)
            {
                anim.SetBool("run", true);
                rgb.velocity = new Vector2(-Speed, rgb.velocity.y);
                transform.localRotation = Quaternion.Euler(0, 0, 0);
                //Debug.Log("Left");
            }

        }
        if ((rayLeft.collider == null) || (rayRight.collider == null)) anim.SetBool("stand", true); 
    }

    void Death()
    {
        explosion.transform.position = transform.position;
        Instantiate(explosion);
        Destroy(GameObject.Find("bullet"));
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        //explosion.transform.position = other.transform.position; 
        if (other.tag == "bullet")
        {
            //Debug.Log("Hi");
            Health -= DamageInRat;
        }   
        if (Health <= 0) 
        {
            Death();
        }
        if ((other.tag == "DieSpace") || (other.tag == "Enemy"))
        {
            Death();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy") Death();
    }
}