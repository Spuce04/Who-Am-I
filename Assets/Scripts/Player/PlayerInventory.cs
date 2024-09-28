using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public GameObject currentInventoryItem {  get; private set; }
    private GameObject ally;

    public bool isHoldingItem {  get; private set; }
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    // adds interacted item to player inventory if the player isn't already holding an item
    public void PickUpItem(GameObject newItem)
    {
        if(!isHoldingItem && newItem.tag != "Ally")
        {
            currentInventoryItem = newItem;
            isHoldingItem = true;

            currentInventoryItem.transform.parent = this.gameObject.transform;
            currentInventoryItem.transform.localPosition = new Vector3(1f, 0.5f, 2f);
        }
        else if (newItem.tag == "Ally")
        {
            ally = newItem;

            ally.transform.parent = this.gameObject.transform;
            ally.transform.localPosition = new Vector3(-1f, 0f, 1.25f);
            ally.transform.localRotation = new Quaternion(0, 140f, 0, 0);
        }
    }

    public void DropCurrentItem()
    {
        currentInventoryItem.transform.parent = null;
        currentInventoryItem = null;
        isHoldingItem = false;
    }
}
