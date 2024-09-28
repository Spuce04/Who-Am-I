using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPauseGame : MonoBehaviour
{
    private GameManager gameManager;
    [SerializeField]
    private GameObject pauseMenu;
    private GameObject currentCanvas;// the current canvas that is being displayed

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    
    void Update()
    {
        // closes a menu if one is already opened
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (currentCanvas != null)
            {
                CloseMenu();
                return;
            }
        // opens the pause menu if there is no menus open and player presses escape
            else
            {
                OpenMenu(pauseMenu);
                return;
            }
        }
        // quick restart button for the player
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
    }

    // opens specific menu if no other ones are open
    public void OpenMenu(GameObject Canvas)
    {
        if (currentCanvas == null)
        {
            currentCanvas = Canvas;
            Canvas.SetActive(true);
            gameManager.TogglePause();
        }
    }

    // closes the current open menu
    public void CloseMenu()
    {
        if(currentCanvas != null)
        {
            gameManager.TogglePause();
            currentCanvas.SetActive(false);
            currentCanvas = null;
        }
    }

    public void RestartGame()
    {
        gameManager.StartGame();
    }
}
