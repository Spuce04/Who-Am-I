using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinerEntranceKeyhole : Keyhole
{
    void Start()
    {
        animator = GetComponentInParent<Animator>();
        textPrompt = "Use Keyhole \n [E]";
        keyType = "DinerEntranceKey";
    }

}
