using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingTrap : MonoBehaviour
{
    Bullet bullet;
    public bool rotBul;
    public float SpeedShoot = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Shoot()); 
    }

    private void Awake()
    {
        bullet = Resources.Load<Bullet>("Laserbullet");
    }

    IEnumerator Shoot()
    {
        while (true)
        {                    
            yield return new WaitForSeconds(SpeedShoot);
            Vector3 position = transform.position;
            position.y += 0f;
            Bullet newBullet = Instantiate(bullet, position, bullet.transform.rotation) as Bullet;
            if (rotBul == true)
            {
                newBullet.Direction = newBullet.transform.right;
            }
            else
            {
                newBullet.Direction = -newBullet.transform.right;
               
            }
        }
    }
}
