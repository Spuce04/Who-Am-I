using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : Button
{

    public override void OnClick()
    {
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().StartGame();
    }
}
