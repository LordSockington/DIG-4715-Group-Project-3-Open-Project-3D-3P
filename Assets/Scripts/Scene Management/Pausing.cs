using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class Pausing : MonoBehaviour
{
    public GameObject pauseMenu;

    public static bool isPaused = false;

    /* 
    public delegate void Paused();
    public static event Paused currentlyPaused; // These 2 events are so the camera doesn't move while pause, need to add that I believe

    public delegate void isntPaused();
    public static event isntPaused notPaused; 
    */

    void OnPause(InputValue pause)
    {
        if (isPaused == true)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        //notPaused.Invoke();
    }

    void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        //currentlyPaused.Invoke();
    }

    public void ReturnToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
