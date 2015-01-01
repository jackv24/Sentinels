using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Button))]
public class ReflectButtonInput : MonoBehaviour
{
    //The input button that this button must simulate
    public string inputButton = "AbilityX";

    private Button button;

    void Start()
    {
        //The button component that should be attached to this gameobject
        button = GetComponent<Button>();
    }

    void Update()
    {
        if (Preferences.instance.gameState == Preferences.GameState.Running)
        {
            //If a mouse button is clicked over a GUI object, do nothing.
            if (inputButton == "Primary" || inputButton == "Secondary")
                if (EventSystem.current.IsPointerOverGameObject())
                    return;

            //If the key for this gui button is pressed, reflect that by disabling and enabling the button
            if (Input.GetButton(inputButton))
                button.interactable = false;
            else
                button.interactable = true;
        }
    }
}
