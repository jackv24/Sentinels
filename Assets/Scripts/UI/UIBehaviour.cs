using UnityEngine;
using System.Collections;

//Holds a bunch of UI functions
public class UIBehaviour : MonoBehaviour
{
    //Stores an array of panels - to be opened and closed
    public GameObject[] panels;
    private int lastPanelIndex = -1;

    void Start()
    {
        ClosePanels();
    }

    #region options
    public void setMasterVolume(float value)
    {
        Preferences.instance.masterVolume = value;
    }

    public void setMusicVolume(float value)
    {
        Preferences.instance.musicVolume = value;
    }

    public void setSoundVolume(float value)
    {
        Preferences.instance.soundVolume = value;
    }
    #endregion

    #region panels
    public void OpenPanel(int index)
    {
        ClosePanels();

        if (lastPanelIndex != index)
        {
            panels[index].SetActive(true);
            lastPanelIndex = index;
        }
        else
            lastPanelIndex = -1;
    }

    public void ClosePanels()
    {
        foreach (GameObject panel in panels)
        {
            panel.SetActive(false);
        }
    }
    #endregion

    #region levels
    public void LoadLevel(int index)
    {
        Application.LoadLevel(index);
    }

    public void LoadLevel(string name)
    {
        Application.LoadLevel(name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ReloadLevel()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
    #endregion
}
