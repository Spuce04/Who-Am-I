using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuggyDrive : MonoBehaviour
{
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.Play("Drive");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
