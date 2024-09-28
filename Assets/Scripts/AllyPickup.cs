using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyPickup : InventoryItemPickup
{
    // Start is called before the first frame update
    void Start()
    {
        textPrompt = "Pick Up Ally \n [E]";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Use()
    {
        base.Use();
        GetComponent<Ally>().UpdateScreenDisplay();
        GameObject.FindGameObjectWithTag("PuzzleManager").GetComponent<PuzzleManager>().ActivateCollectionPuzzle();// activates the ally puzzle when the ally is picked up
    }
}
