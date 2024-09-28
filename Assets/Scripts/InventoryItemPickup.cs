using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItemPickup : Interactable
{
    void Start()
    {
        textPrompt = "Pick Up Item \n [E]";
    }

    // Adds item to inventory
    public override void Use()
    {
        PlayerInventory inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>();
        inventory.PickUpItem(this.gameObject);
    }
}
