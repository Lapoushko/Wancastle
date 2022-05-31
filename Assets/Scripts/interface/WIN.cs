using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WIN : MonoBehaviour
{
    public int LevelEnd;
    public GameObject PanelLvlWin;
    public GameObject target;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PanelLvlWin.SetActive(true);
            target.SetActive(false);
        }
    }

    
}
