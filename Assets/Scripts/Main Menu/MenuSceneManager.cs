using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSceneManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void MainGame()
    {
        SceneManager.LoadScene("Game Level");
    }

    // public void Spare()
    // {
    //     SceneManager.LoadScene("");
    // }

    public void Quit()
    {
        Application.Quit();
    }
}
