using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    protected string displayText;
    public string textPrompt {  get; set; }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void Use()
    {

    }

    public virtual bool PlaceItem(GameObject item)
    {
        return false;
    }
}
