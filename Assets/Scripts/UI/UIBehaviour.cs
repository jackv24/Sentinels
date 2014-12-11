using UnityEngine;
using System.Collections;

public class UIBehaviour : MonoBehaviour
{
    public GameObject[] panels;

    void Start()
    {
        ClosePanels();
    }

    #region options
    public void setMasterVolume(float value)
    {
        Preferences.masterVolume = value;
    }

    public void setMusicVolume(float value)
    {
        Preferences.musicVolume = value;
    }

    public void setSoundVolume(float value)
    {
        Preferences.soundVolume = value;
    }
    #endregion

    #region panels
    public void OpenPanel(int index)
    {
        ClosePanels();

        panels[index].SetActive(true);
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
    #endregion
}
