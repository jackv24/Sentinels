using UnityEngine;
using System.Collections;

public class PauseGame : MonoBehaviour
{
    public GameObject pauseMenu;

    private bool isGamePaused = false;

    void Start()
    {
        isGamePaused = Preferences.instance.isGamePaused;
        pauseMenu.SetActive(isGamePaused);
    }

    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
            TogglePauseGame();
    }

    public void TogglePauseGame()
    {
        isGamePaused = !isGamePaused;

        if (isGamePaused)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;

        pauseMenu.SetActive(isGamePaused);

        Preferences.instance.isGamePaused = isGamePaused;
        Preferences.instance.canPlayerShoot = !isGamePaused;
    }
}
