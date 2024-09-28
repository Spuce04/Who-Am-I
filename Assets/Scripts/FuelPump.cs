using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelPump : Interactable
{
    private int price = 40;
    Ally ally;
    void Start()
    {
        textPrompt = "Pay \n[E]";
        ally = GameObject.FindGameObjectWithTag("Ally").GetComponent<Ally>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Use()
    {
        if (ally.money >= price && ally.batteryCount >= ally.maxBatterycount)
        {
            GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().CompleteGame();
        }
    }
}
