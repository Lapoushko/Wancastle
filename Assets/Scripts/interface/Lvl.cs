using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lvl : MonoBehaviour
{
    public int Levels = 1;
    [SerializeField]
    Sprite open;
    [SerializeField]
    Sprite close;
    int levelComplete;

    void Start()
    {
        levelComplete = PlayerPrefs.GetInt("LevelComplete");
        for (int i = 0; i < transform.childCount; i++)
        {
            if (i < levelComplete)
            {
                transform.GetChild (i).GetComponent<Image>().sprite = open;
                transform.GetChild(i).GetComponent<Button>().interactable = true;
            }
            if (i > levelComplete)
            {
                transform.GetChild(i).GetComponent<Image>().sprite = close;
                transform.GetChild(i).GetComponent<Button>().interactable = false;
            }

        }
    }

}
