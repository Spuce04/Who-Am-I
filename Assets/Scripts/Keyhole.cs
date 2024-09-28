using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keyhole : Interactable
{
    protected bool unlocked = false;
    protected string keyType;
    protected Animator animator;
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        textPrompt = "Use Keyhole \n [E]";
    }

    // checks if the input item matches the keytype. If it does, then the door will open and key will be destroyed
    public override bool PlaceItem(GameObject item)
    {
        if (item != null && item.tag == keyType && !unlocked)
        {
            Destroy(item);
            animator.Play("Open");
            textPrompt = "";
            OnOpen();
            return true;
        }
        else
        {
            return false;
        }
    }

    // anything that needs to happen for specific inherited classes when the door opens will be placed here
    public virtual void OnOpen()
    {

    }
}
