using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovePlayer : MonoBehaviour
{
    private int levelComplete;
    private bool lvlBool = false;

    public GameObject PanelWin;
    public AudioSource RunningAudio;

    public int levelNext;
    //
    public AudioSource AudioShoot;
    AudioSource AudioS;
    //
    public GameObject TextOnTable;

    public GameObject AgainPanel;

    public int damage = 20;
    public float damageInPlayer = 1f;

    public float Life = 5;
    public float maxHp;
    public float differenceHp;

    public float accseleration;
    Rigidbody2D rb;
    public float horizontalSpeed;
    float speedx;
    public float verticalimpulse;
    public bool jump;
    Animator anim;

    public GameObject OpenPanelLvl;

    public GameObject ParticleCheckpoint;
    public GameObject ParticleBulletDawn;
    public GameObject ParticleSpawn;
    public GameObject ParticleUpBullets;
    public GameObject ParticleUp;
    public GameObject explosion;

    public float spawn = 1f;
    public GameObject person;

    public int Checkpoint = 1;

    public bool EndLevel = false;
    public bool canPoint;
    public Transform ThirdPoint;
    public Transform SecondPoint;
    public Transform StartRespawn;

    bool canShoot = false;
    Bullet bullet;
    SpriteRenderer sprite;
    public bool rotBullet = true;
    public bool canBul = true;
    public bool run;
    public bool ParticlesCheck1 = true;
    public bool ParticlesCheck2 = true;

    public int giveBul;
    public int ammo = 10;
    public int differenceAmmo = 11;
    public int maxBul = 50;

    public int levelIndex;
    //public Vector3 direction;

    //
    public LayerMask WhatIsGround;
    public Transform GroundCheck;
    public float groundRadius;

    //


    void Start()
    {
        AudioS = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        person.SetActive(false);
        Invoke("PersonActive", spawn);
        levelIndex = SceneManager.GetActiveScene().buildIndex;
    }

    void PersonActive()
    {
        ParticleSpawn.transform.position = person.transform.position;
        Instantiate(ParticleSpawn);
        canShoot = true;
        person.SetActive(true);
    }

    public void BulletBtn()
    {
        Shoot();
    }


    void Awake()
    {
        bullet = Resources.Load<Bullet>("bullet");
    }


    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.A)) LeftButtonDown(); else if (Input.GetKeyUp(KeyCode.A)) Stop();
        if (Input.GetKeyDown(KeyCode.D)) RightButtonDown(); else if (Input.GetKeyUp(KeyCode.D)) Stop();
        if (Input.GetKeyDown(KeyCode.W)) OnClickJump();
        if (Input.GetKeyUp(KeyCode.S)) Shoot();

        jump = Physics2D.OverlapCircle(GroundCheck.position, groundRadius, WhatIsGround);


        if (ammo >= maxBul) ammo = maxBul;
        transform.Translate(speedx, 0, 0);
        if (Life <= 0)
        {
            Instantiate(explosion);
            Destroy(gameObject);
            AgainPanel.SetActive(true);
        }

    }

    //Поворот налево
    public void LeftButtonDown()
    {
        
            transform.rotation = Quaternion.Euler(0, 180, 0); //Поворот персонажа в обратную сторону
            if (jump == true)
            {
                anim.SetBool("Move", true); //анимация бега персонажа
                RunningAudio.Play();
            }
            else
            {
                anim.SetBool("Move", true); //анимация бега персонажа
                RunningAudio.Stop();
            }
            rotBullet = false;
            speedx = horizontalSpeed * Time.fixedDeltaTime; 
    }
    //Поворот направо
    public void RightButtonDown()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
        if (jump == true)
        {
            anim.SetBool("Move", true); //анимация бега персонажа
            RunningAudio.Play();
        }
        else
        {
            anim.SetBool("Move", true); //анимация бега персонажа
            RunningAudio.Stop();
        }

        rotBullet = true;
        speedx = horizontalSpeed * Time.fixedDeltaTime;
    }
    //Обнуление скорости
    public void Stop()
    {
        RunningAudio.Stop();
        speedx = 0;
        anim.SetBool("Move", false);

    }

    public void OnClickMenu()
    {
        OpenPanelLvl.SetActive(true);
        
    }
    //Прыжок игрока
    public void OnClickJump()
    {
        if (jump == true)
        {
            rb.AddForce(new Vector2(0, verticalimpulse), ForceMode2D.Impulse);
            jump = false;
            //anim.SetBool("isJumping", true); //анимация прыжка
        }
        else RunningAudio.Stop();

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (((collision.gameObject.tag == "Platform") || (collision.gameObject.tag == "ShootingTrap") || (collision.gameObject.tag == "Land")))
        //{
          //  jump = true;    
        //}
        
        switch (collision.gameObject.tag)
        {
            case "Enemy" :
                Hit();
                break;
            case "Saw":
                Hit();
                break;
            case "PrickyBall":
                Hit();
                break;
            case "Spike":
                Hit();
                break;
            case "BOSS":
                Hit();
                break;
        }
    }


    void Shoot()
    {   if (canShoot == true)
        {
            
            anim.SetBool("Shoot", true);//анимация стрельбы
            if (canBul == true)
            {
                ammo--;
                Vector3 position = transform.position;
                position.y += -0.16f;
                if (rotBullet == true) position.x += 2f;
                else position.x -= 2f;

                Bullet newBullet = Instantiate(bullet, position, bullet.transform.rotation) as Bullet;
               
                if (rotBullet == true)
                {
                    newBullet.Direction = newBullet.transform.right;
                }
                else
                {
                    newBullet.Direction = -newBullet.transform.right;
                }

                if (ammo == 0) canBul = false;
                ParticleBulletDawn.transform.position = person.transform.position;
                Instantiate(ParticleBulletDawn);
                AudioShoot.Play();

            }
           
            if (canBul == false) anim.SetBool("Shoot", false);
            if (ammo > 0) canBul = true;
            StartCoroutine("TimeAnim");
        }
    }

    IEnumerator TimeAnim()
    {
        yield return new WaitForSeconds(0f);
        anim.SetBool("Shoot", false);
    }

    //Проверка столкновения игрока с платформой 2
    //private void OnCollisionExit2D(Collision2D collisions)
    //{
    //  if (((collisions.gameObject.tag == "Platform") || (collisions.gameObject.tag == "ShootingTrap") || (collisions.gameObject.tag == "Land")))
    // {
    //    jump = false;
    // }
    // }

    private void OnTriggerEnter2D(Collider2D other)
    {
        ParticleCheckpoint.transform.position = other.transform.position;
        if (other.tag == "SecondCheckpoint")
        { 
            Checkpoint = 2;
            if (ParticlesCheck1 == true)
            {
                Instantiate(ParticleCheckpoint);
                ParticlesCheck1 = false;
            }
        }       

        if (other.tag == "ThirdCheckpoint") 
        {
            Checkpoint = 3;
            if (ParticlesCheck2 == true)
            {
                Instantiate(ParticleCheckpoint);
                ParticlesCheck2 = false;
            }
        }
        if (other.tag == "PrickyBall")
        {
            Hit();
        }
        if (other.tag == "BOSS")
        {
            Hit();
            if (EndLevel == true)
            {
                Checkpoint = Random.Range(1, 3);
            }
        }
        //
        ParticleUpBullets.transform.position = other.transform.position;
        ParticleUp.transform.position = other.transform.position;
        explosion.transform.position = other.transform.position;
        //
        if (ammo <= 30)
        {
            if ((ammo >= 20) && (ammo <= 30))
            {
                if (other.tag == "BoxBul")
                {
                    Instantiate(ParticleUpBullets);
                    differenceAmmo = maxBul - ammo;
                    ammo = ammo + differenceAmmo;
                    Destroy(GameObject.FindWithTag("BoxBul"));
                }
                
            }
            if (differenceAmmo >= 10)
            {
                if (other.tag == "BoxBul")
                {
                    Instantiate(ParticleUpBullets);
                    ammo += giveBul;
                    Destroy(GameObject.FindWithTag("BoxBul"));
                    canBul =true;
                }
            }
        }

        if (Life <= maxHp)
        {
            if ((Life >= maxHp*0.5) && (Life <= maxHp))
            {
                if (other.tag == "BoxHP")
                {
                    Instantiate(ParticleUp);
                    differenceHp = maxHp - Life;
                    Life += differenceHp;
                    Destroy(GameObject.FindWithTag("BoxHP"));
                }
            }

            if (differenceHp > maxHp*0.5) 
            {
                if (other.tag == "BoxHP")
                {
                    Instantiate(ParticleUp);
                    Life += maxHp/2;
                    Destroy(GameObject.FindWithTag("BoxHP"));
                }
            }
        }
        if (other.tag == "LaserBullet")
        {
            if (Life == 1)
            {
                Life = 0;
            }
            else
            {
                Life -= 1f;
            }
            if (Checkpoint == 1)
            {
                transform.position = StartRespawn.transform.position;
            }
            else if (Checkpoint == 2)
            {
                transform.position = SecondPoint.transform.position;
            }
            else if (Checkpoint == 3)
            {
                transform.position = ThirdPoint.transform.position;
            }
            AudioS.Play();
        }

        if (other.tag == "DieSpace")
        {
            if (Life == 1)
            {
                Life = 0;
            }
            else
            {
                Life -= 1f;
            }
            if (Checkpoint == 1)
            {
                transform.position = StartRespawn.transform.position;
            }
            else if (Checkpoint == 2)
            {
                transform.position = SecondPoint.transform.position;
            }
            else if (Checkpoint == 3)
            {
                transform.position = ThirdPoint.transform.position;
            }
            AudioS.Play();
        }
        if (other.tag == "NextLevelTrigDown")
        {
            PanelWin.SetActive(true);
            levelComplete = PlayerPrefs.GetInt("LevelComplete");
            if (levelComplete <= levelIndex)
            {
                PlayerPrefs.SetInt("LevelComplete", levelIndex);
            }
        } 
        
        
    }
    void Hit()
    {
        if (Life == 1)
        {
            Life = 0;
        }
        else
        {
            Life -= 1f;
        }
        if (Checkpoint == 1)
        {
            transform.position = StartRespawn.transform.position;
        }
        else if (Checkpoint == 2)
        {
            transform.position = SecondPoint.transform.position;
        }
        else if (Checkpoint == 3)
        {
            transform.position = ThirdPoint.transform.position;
        }
        AudioS.Play();
    }
}