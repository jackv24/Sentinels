using UnityEngine;
using System.Collections;

public class Preferences : MonoBehaviour
{
    public enum GameState
    {
        Running,
        Building,
        Paused
    }

    public GameState gameState = GameState.Running;

    //Static instance, for easy access without using GetComponent()
    public static Preferences instance;

    public float masterVolume = 1f;
    public float musicVolume = 1f;
    public float soundVolume = 1f;

    void Start()
    {
        instance = this;

        //Load saved preferences
        Load();
    }

    //When gameobject is disabled (new scene is loaded)
    void OnDisable()
    {
        //Save preferences
        Save();
    }

    void Save()
    {
        //Save volume preferences
        PlayerPrefs.SetFloat("masterVolume", masterVolume);
        PlayerPrefs.SetFloat("musicVolume", musicVolume);
        PlayerPrefs.SetFloat("soundVolume", soundVolume);
    }

    void Load()
    {
        //Load volume preferences
        masterVolume = PlayerPrefs.GetFloat("masterVolume", 1f);
        musicVolume = PlayerPrefs.GetFloat("musicVolume", 1f);
        soundVolume = PlayerPrefs.GetFloat("soundVolume", 1f);
    }
}
