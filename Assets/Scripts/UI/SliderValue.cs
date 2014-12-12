using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SliderValue : MonoBehaviour
{
    //Text to display slider value on
    public Text text;

    //The key to use when loading the slider value from PlayerPrefs
    public string prefsKey = "";

    //This slider
    private Slider slider;

    void Start()
    {
        slider = GetComponent<Slider>();

        //Load slider value
        slider.value = PlayerPrefs.GetFloat(prefsKey, 1f);
    }

    void Update()
    {
        //Set text to slider value as a percentage
        text.text = Mathf.RoundToInt(slider.value * 100) + "%";
    }
}
