using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenKeypad : Interactable
{
    private ParticleSystem particleSystem;

    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
        textPrompt = "Try Passcode \n [E]";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Use()
    {
        particleSystem.Play();
        textPrompt = "AAAAHHHH SPARKS!!";
    }
}
