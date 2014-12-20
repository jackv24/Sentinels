using UnityEngine;
using System.Collections;

public class PauseGame : MonoBehaviour
{
    //The gameobject containing the pause menu (to be enabled and disabled)
    public GameObject pauseMenu;

    //Is the game paused?
    private bool isGamePaused = false;

    void Start()
    {
        //Sets isGamePaused to the universal game pause state
        isGamePaused = Preferences.instance.isGamePaused;
        //Sets the pausemenu active state accordingly
        pauseMenu.SetActive(isGamePaused);
    }

    void Update()
    {
        //When the cancel button is pressed (should be 'esc'), toggle game pause state
        if (Input.GetButtonDown("Cancel"))
            TogglePauseGame();
    }

    public void TogglePauseGame()
    {
        //Toggles the game pause state
        isGamePaused = !isGamePaused;

        //if the game is paused
        if (isGamePaused)
            Time.timeScale = 0; //Pause everything (that is affected by time)
        else
            Time.timeScale = 1; //Unpause everything

        //Hide or show the pause menu
        pauseMenu.SetActive(isGamePaused);

        //Set universal pause state
        Preferences.instance.isGamePaused = isGamePaused;

        //Set if player can shoot (seperate from game pause to stop player shooting in menus)
        Preferences.instance.canPlayerShoot = !isGamePaused;
    }
}
