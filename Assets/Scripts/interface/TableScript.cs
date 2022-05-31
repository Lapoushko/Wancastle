using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableScript : MonoBehaviour
{
    public GameObject TextOnTable;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            TextOnTable.SetActive(true);
        }
        if (other.tag != "Player") TextOnTable.SetActive(false);
    }
}
