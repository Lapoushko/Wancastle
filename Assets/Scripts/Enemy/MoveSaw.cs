using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSaw : MonoBehaviour
{
    public float TransfPos;
    public float Speed = 1;
    public Transform point_1;
    public Transform point_2;
    Rigidbody2D rgb;
    bool OnRight;

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
        }
        else
        {
           // transform.position = Vector2.Lerp(rgb.position, point_1.transform.position, Speed * Time.deltaTime);
            rgb.velocity = new Vector2(-Speed, rgb.velocity.y);
            //transform.localRotation = Quaternion.Euler(0, 0, 0); //Поворот персонажа в обратную сторону
        }
    }

   
}