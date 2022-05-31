using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextAmmo : MonoBehaviour
{
    public Text txt;
    public MovePlayer Player;

    void Start()
    {

    }
    void Update()
    {
        txt.text = Player.ammo.ToString();
    }
}
