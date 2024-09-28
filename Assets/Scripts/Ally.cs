using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ally : MonoBehaviour
{
    private string[] dialogue = new string[7];// the text that will be displayed on screen of the ally device
    private TextMeshProUGUI dialogueDisplay;// text of the canvas for the screen

    private int powerPercentage = 5;// power that is displayed on screen
    public int batteryCount { get; private set; } = 0;// how many batteries the player has collected for the ally
    public int maxBatterycount { get; private set; } = 5;// how many batteries the ally is able to collect
    private TextMeshProUGUI powerDisplay;


    public int money { get; private set; }
    private TextMeshProUGUI moneyDisplay;

    private void Awake()
    {
        dialogue[0] = "Hey you, I recognise you...";
        dialogue[1] = "It seems I need more power, look around for some batteries.";
        dialogue[2] = "Looks like your name is Collin, find more batteries.";
        dialogue[3] = "Apparently you were born in 2010, I still need more batteries.";
        dialogue[4] = "How are you still alive!? the year is 2231! lets find more batteries.";
        dialogue[5] = "Evidence shows we're still in the apocalypse, yikes! find more batteries.";
        dialogue[6] = "There's no nearby power sources, let's drive to the city. Find $40 and pay for fuel at the pump.";

        dialogueDisplay = GameObject.FindGameObjectWithTag("AllyDialogueDisplay").GetComponent<TextMeshProUGUI>();
        powerDisplay = GameObject.FindGameObjectWithTag("AllyPowerDisplay").GetComponent<TextMeshProUGUI>();
        moneyDisplay = GameObject.FindGameObjectWithTag("AllyMoneyDisplay").GetComponent<TextMeshProUGUI>();
    }
    void Start()
    {
        dialogueDisplay.SetText(dialogue[0]);
        powerDisplay.SetText("Power: " + powerPercentage + "%");
        moneyDisplay.SetText("Money: $" + money);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // sets the scren of the ally based on stats (how many items the player has collected)
    public void UpdateScreenDisplay()
    {
        dialogueDisplay.SetText(dialogue[batteryCount + 1]);
        powerDisplay.SetText("Power: " + powerPercentage + "%");
        moneyDisplay.SetText("Money: $" + money);
    }

    // allows the ally to collect money and batteries
    public void CollectItem(GameObject item)
    {
        if (item.tag == "Batteries")
        {
            powerPercentage += Random.Range(5, 11);
            batteryCount++;
            Destroy(item.gameObject);
        }
        else if (item.tag == "Money")
        {
            money += 5;
            Destroy(item.gameObject);
        }
        UpdateScreenDisplay();
    }
}
