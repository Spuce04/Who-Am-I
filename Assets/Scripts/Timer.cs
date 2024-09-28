using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float time = 0;
    private bool running = false;
    void Start()
    {
        
    }

    void Update()
    {
        if (running)
        {
            time += Time.deltaTime;
            Debug.Log(time);
        }
    }

    public void ResetTimer()
    {
        time = 0;
    }

    public void StartTimer()
    {
        running = true;
    }

    public void PauseTimer()
    {
        running = false;
    }

    public float GetTime()
    {
        return (float)Math.Round(time, 3);
    }
}
