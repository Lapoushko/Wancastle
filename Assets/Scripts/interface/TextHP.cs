using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextHP : MonoBehaviour
{
    public MovePlayer Player;
    public Text text;

    void Start()
    {
        
    }

   
    void Update()
    {
        text.text = Player.Life.ToString();
    }
}
