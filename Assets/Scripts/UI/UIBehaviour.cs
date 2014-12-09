using UnityEngine;
using System.Collections;

public class UIBehaviour : MonoBehaviour
{
    public GameObject[] panels;

    void Start()
    {
        ClosePanels();
    }

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
}
