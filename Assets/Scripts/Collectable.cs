using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : Interactable
{
    void Start()
    {
        textPrompt = "Collect Item\n [E]";
    }

    // item is collected by the ally when interacted with from the player
    public override void Use()
    {
        GameObject.FindGameObjectWithTag("Ally").GetComponent<Ally>().CollectItem(this.gameObject);
    }
}
