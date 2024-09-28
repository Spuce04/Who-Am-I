using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterKeyhole : Keyhole
{
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        textPrompt = "Use Keyhole \n [E]";
        keyType = "CounterKey";
    }
}
