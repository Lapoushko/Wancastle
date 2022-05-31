using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpBlackScreenBlock : MonoBehaviour
{
    public Rigidbody2D rgb;
    public float speedy;
    public bool rot;

    public void FixedUpdate()
    {
        Invoke("MoveBlock", 1f);
        Invoke("DEst", 4f);
    }
    
    public void MoveBlock()
    {
        if (rot == true) transform.Translate(Vector2.up * speedy* Time.deltaTime);
        if (rot == false) transform.Translate(Vector2.up * -speedy * Time.deltaTime);
    }
    public void DEst()
    {
        Destroy(gameObject);
    }
}
