using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject gameOverUI;
    public GameObject secretMenu;
    public GameObject winUI;
    public static bool gameOver = false;
    public static bool isPaused = false;
    void Awake()
    {
        gameOver = false;
        isPaused = false;
    }
    void Update()
    {
        if(gameOver) GameOver();
        Time.timeScale = isPaused ? 0f : 1f;
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused) ResumeGame();
            else PauseGame();
        } 
        if(SceneManager.GetActiveScene().name != "MainMenu" || !winUI.activeInHierarchy)
            Cursor.visible = isPaused;
        else
            Cursor.visible = true;
    }
    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        isPaused = false;
    }
    void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        isPaused = true;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void GameOver()
    {
        gameOverUI.SetActive(true);
        isPaused = true;
    }
    public void SecretMenu()
    {
        secretMenu.SetActive(true);
    }
    public void Win()
    {
        winUI.SetActive(true);
    }
}
