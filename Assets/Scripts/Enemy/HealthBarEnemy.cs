using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarEnemy : MonoBehaviour
{
    public float changeSpeed;
    public Image bar;
    public MoveBoss Enemy;
    public float fill;
    public GameObject HpBar;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        fill = Enemy.hp / Enemy.maxHp;
        bar.fillAmount = fill;

    }
}
