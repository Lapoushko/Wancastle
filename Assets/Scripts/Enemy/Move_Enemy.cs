using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Enemy : MonoBehaviour
{
    public GameObject explosion;
    public MovePlayer Player;
    [SerializeField]
    public bool IsDeathEnemy;
    public AudioSource AudioDeath;

    public float Speed = 1;
    public Transform point_1;
    public Transform point_2;
    Rigidbody2D rgb;
    bool OnRight;
    public float hp = 60;
    public Animator anim;

    private void Start()
    {
        anim.SetBool("Move", true);
    }

    void Awake()
    {
        rgb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (gameObject.transform.position.x <= point_2.position.x)
        {
            OnRight = true;
        }
        if (gameObject.transform.position.x >= point_1.position.x)
        {
            OnRight = false;
        }

        MakePosition();
    }

    void MakePosition()
    {
        if (OnRight)
        {
            rgb.velocity = new Vector2(Speed, rgb.velocity.y);
            //transform.localRotation = Quaternion.Euler(0, 0, 0); //Поворот персонажа в обратную сторону
            transform.rotation = Quaternion.Euler(0, 180, 0); //Поворот персонажа в обратную сторону
            //anim.SetBool("Move", true);
        }
        else
        {
            rgb.velocity = new Vector2(-Speed, rgb.velocity.y);
            //transform.localRotation = Quaternion.Euler(0, 180, 0); //Поворот персонажа в обратную сторону
            transform.rotation = Quaternion.Euler(0, 0, 0); //Поворот персонажа в обратную сторону
            //anim.SetBool("Move", true);
        }
    }


   private void OnTriggerEnter2D(Collider2D other)
    {
        explosion.transform.position = other.transform.position;
        if (other.tag == "bullet")
        {
            hp -= Player.damage;
            Destroy(GameObject.Find("bullet"));
        }
        if (hp <= 0)
        {
            Instantiate(explosion);           
            Destroy(GameObject.Find("bullet"));
            Destroy(gameObject); 
        }
    }
}