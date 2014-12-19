using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Button))]
public class UIButtonInput : MonoBehaviour
{
    public string inputButton = "AbilityX";

    private PlayerAbilities playerAbilities;

    private Button button;

    void Start()
    {
        playerAbilities = GameObject.FindWithTag("Player").GetComponent<PlayerAbilities>();

        button = GetComponent<Button>();
    }

    void Update()
    {
        if (inputButton == "Primary" || inputButton == "Secondary")
            if (EventSystem.current.IsPointerOverGameObject())
                return;

        if (Input.GetButton(inputButton))
            button.interactable = false;
        else
            button.interactable = true;
    }

    public void PressButton()
    {
        playerAbilities.GetUIInput(inputButton);
    }
}
