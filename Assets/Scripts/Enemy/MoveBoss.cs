using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveBoss : MonoBehaviour
{
    public GameObject explosion;
    public MovePlayer Player;
    [SerializeField]
    public Slider hpbarBoss;

    Vector2 velocity = Vector2.zero;
    public float distance;
    Transform target;
    public float smoothTime;
    public GameObject PanelWin;

    public float Speed = 1;
    Rigidbody2D rgb;
    public float hp = 60;
    public float maxHp;

    // Start is called before the first frame update
    void Start()
    {
        maxHp = hp;
        explosion.transform.position = transform.position;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rgb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < target.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else transform.rotation = Quaternion.Euler(0, 0, 0);
        transform.position = Vector2.MoveTowards(transform.position, target.position, Speed * Time.deltaTime);
        hpbarBoss.value = hp;
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
            PanelWin.SetActive(true);
        }
    }
}
