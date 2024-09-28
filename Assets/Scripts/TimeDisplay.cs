using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeDisplay : MonoBehaviour
{
    private Timer timer;
    private TextMeshProUGUI text;
    void Start()
    {
        if(GameObject.FindGameObjectWithTag("GameManager") != null)
        {
            timer = GameObject.FindGameObjectWithTag("GameManager").GetComponent<Timer>();
        }
        text = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        //updates the display for the timer
        text.SetText(timer.GetTime().ToString());
    }
}
