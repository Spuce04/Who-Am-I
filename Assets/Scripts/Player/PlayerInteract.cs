using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private PlayerInventory inventory;
    private RaycastHit hit;
    private TextMeshProUGUI interactDisplay;
    GameManager gameManager;
    void Start()
    {
        inventory = GetComponent<PlayerInventory>();
        interactDisplay = GameObject.FindGameObjectWithTag("InteractDisplay").GetComponent<TextMeshProUGUI>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Interact();
    }

    // interacts with any object hit by a raycast if its interactable and the player presses 'E'
    // will change UI based on the text prompt from the interactable
    // if the player is holding an item in their inventory, will atempt to use the held item ib the interactable object
    private void Interact()
    {
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 3) && hit.collider.GetComponent<Interactable>() != null && !gameManager.gamePaused)
        {
            Interactable interactable = hit.collider.GetComponent<Interactable>();

            if (interactable.textPrompt != null)
            {
                interactDisplay.SetText(interactable.textPrompt);
            }
            
            if (Input.GetKeyDown(KeyCode.E))
            {
                interactable.Use();

                if (interactable.PlaceItem(inventory.currentInventoryItem) == true)
                {
                    inventory.DropCurrentItem();
                }
            }
        }
        else
        {
            interactDisplay.SetText("");
        }
    }
}
