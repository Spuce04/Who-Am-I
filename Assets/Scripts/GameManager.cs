using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    Timer timer;
    public bool gamePaused { get; private set; } = false;
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        timer = gameObject.AddComponent<Timer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Level");
        timer.ResetTimer();
        timer.StartTimer();
        HideMouse();
    }

    // pauses and resumes game based on state its in
    public void TogglePause()
    {
        if (gamePaused)
        {
            gamePaused = false;
            Time.timeScale = 1;
            HideMouse();
        }
        else if (!gamePaused)
        {
            gamePaused = true;
            Time.timeScale = 0;
            ShowMouse();
        }
    }

    // finishes game when the player completes final puzzle
    public void CompleteGame()
    {
        timer.PauseTimer();
        SceneManager.LoadScene("EndingMenu");
        ShowMouse();
    }

    public void EndGame()
    {
        Application.Quit();
    }

    private void ShowMouse()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void HideMouse()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
