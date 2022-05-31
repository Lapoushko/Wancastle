using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDown : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "DieSpace") Destroy(gameObject);
    }
}
