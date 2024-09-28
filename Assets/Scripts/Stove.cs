using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stove : Interactable
{
    private GameObject frozenKey;
    private InventoryItemPickup keyPickup;
    private bool iceMelted = false;
    void Start()
    {
        textPrompt = "Use Stove \n [E]";
    }

    public override void Use()
    {
        if(keyPickup != null && iceMelted)
        {
           keyPickup.Use();
           textPrompt = "";
        }
    }

    // places the item if it's a frozen key and begins to melt it
    public override bool PlaceItem(GameObject item)
    {
        if (item != null && item.tag == "FrozenKey" && !iceMelted)
        {
            frozenKey = item;
            keyPickup = frozenKey.GetComponent<InventoryItemPickup>();
            frozenKey.transform.position = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);
            StartCoroutine(MeltIce());
            return true;
        }
        else
        {
            return false;
        }
    }

    // melts the ice of the frozen key after certain amount of time
    private IEnumerator MeltIce()
    {
        yield return new WaitForSeconds(5f);
        frozenKey.GetComponent<FrozenKey>().MeltIce();
        textPrompt = keyPickup.textPrompt;
        frozenKey.tag = "CounterKey";// changes tag so it can be used to unlock the counter keyhole
        iceMelted = true;
    }
}
