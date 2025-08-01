using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSwitching : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject howToPlayScreen;

    public void ReturnToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("TitleScreen");
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ReturnToLevelSelect()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void LoadTrainingRoom()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Training Room");
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void LoadShop()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Shop");
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void OpeningCutscene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("OpeningScene");
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void LoadWesternLevel()
    {
        SceneManager.LoadScene("Western");
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1f;
    }

    public void LoadSentaiLevel()
    {
        SceneManager.LoadScene("Sentai");
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1f;
    }

    public void LoadNoirLevel()
    {
        SceneManager.LoadScene("Noir");
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1f;
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1f;
    }

    public void OpenHowToPlay()
    { 
        pauseMenu.SetActive(false);
        howToPlayScreen.SetActive(true);
    }

    public void CloseHowToPlay()
    {
        pauseMenu.SetActive(false);
        howToPlayScreen.SetActive(false);
    }

    public void BackToPause()
    {
        pauseMenu.SetActive(true);
        howToPlayScreen.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
