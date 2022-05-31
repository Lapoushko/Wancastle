using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarPerson : MonoBehaviour
{
    public float changeSpeed;
    public Image bar;
    public MovePlayer Person;
    public float fill;
    public GameObject HpBar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {        
        fill = Person.Life / Person.maxHp;
        bar.fillAmount = fill;
      
    }
}
