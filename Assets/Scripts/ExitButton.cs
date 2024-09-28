using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButton : Button
{
    public override void OnClick()
    {
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().EndGame();
    }
}
