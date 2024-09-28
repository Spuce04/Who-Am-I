using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Vault : Interactable
{ 
    public string passCode { get; set; }
    private string playerInput;
    private GameObject keyPadUI;
    private TextMeshProUGUI playerInputDisplay;
    private PlayerPauseGame playerPause;

    private void Awake()
    {
        keyPadUI = transform.Find("Canvas").gameObject;
        playerInputDisplay = transform.Find("Canvas").transform.Find("PlayerInputDisplay").GetComponent<TextMeshProUGUI>();
        keyPadUI.SetActive(false);
    }

    void Start()
    {
        playerInput = "";
        textPrompt = "Try Passcode \n [E]";
        playerPause = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerPauseGame>();
    }

    
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.Escape)) && keyPadUI.active)
        {
            CloseUI();
        }
    }

    public override void Use()
    {
        OpenUI();
    }

    // opens UI for entering passcode and pauses game
    private void OpenUI()
    {
        playerPause.OpenMenu(keyPadUI);
    }

    // closes UI for entering the passcode and continues the game
    private void CloseUI()
    {
        ClearPlayerInput();
    }

    // shows the player what they're inputing
    private void UpdateUI()
    {
        playerInputDisplay.text = playerInput;
    }

    // adds a number to the code the player in inputing based on what button is pressed from 0-9
    public void AddToPlayerInput(string NewInput)
    {
        if (playerInput.Length < passCode.Length)
        {
            playerInput += NewInput;
            Debug.Log(playerInput);
            UpdateUI();
        }
    }

    // clears the players current input
    public void ClearPlayerInput()
    {
        playerInput = "";
        UpdateUI();
    }

    // checks if the player has input the correct code by matching it against the actual pass code
    public void TryToUnlock()
    {
        if(playerInput == passCode)
        {
            UnlockVault();
        }
        else
        {
            ClearPlayerInput();
        }
    }

    private void UnlockVault()
    {
        CloseUI();
        gameObject.AddComponent<VaultHandleHole>();
        playerPause.CloseMenu();
        Destroy(this);
    }
}
