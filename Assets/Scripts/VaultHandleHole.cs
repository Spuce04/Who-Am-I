using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaultHandleHole : Keyhole
{
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        textPrompt = "Place Handle \n [E]";
        keyType = "VaultHandle";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnOpen()
    {
        GetComponent<BoxCollider>().enabled = false;
    }
}
