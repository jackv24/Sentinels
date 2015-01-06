using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class UpgradeTowers : MonoBehaviour
{
    //UI object to enable/disable
    public GameObject upgradeUI;

    //The layer on which with grid nodes are
    public LayerMask layer;

    //Is the tower upgrade UI enabled?
    public bool isEnabled;

    //For changing selected tower colour
    public Color selectColour;
    private List<Color> originalColours = new List<Color>();

    //The currently selected tower
    private GameObject tower;
    //Towerstats reference from the currently selected tower
    private TowerStats towerStats;

    private PlayerStats playerStats;

    //--------UI Variables--------//
    //The text element where the tower's name is displayed
    public Text nameText;

    //The image element where the tower's sprite is displayed
    public Image towerImage;
    //The tower's sprite
    private Sprite towerSprite;

    //Health bar variables
    public Slider healthSlider;
    public Text healthText;
    private string healthTextString;

    //XP bar variables
    public Slider xpSlider;
    public Text xpText;
    private string xpTextString;

    //Level bar variables
    public Slider levelSlider;
    public Text levelText;
    private string levelTextString;

    //Text element that displays what upgrades are available
    public Text nextLevelText;

    //The smoothness the bars move when their value is changed
    public float barAnimSmoothness = 0.25f;

    void Start()
    {
        playerStats = GameObject.Find("Player").GetComponent<PlayerStats>();

        //Get initial strings for bar text, so string.Format can be used
        healthTextString = healthText.text;
        xpTextString = xpText.text;
        levelTextString = levelText.text;

        //Start the game with the tower upgrade UI closed
        ToggleUpgradeTowers(false);
    }

    void Update()
    {
        //If the mouse is not over a GUI element, and the game state is set to "Running"...
        if (!EventSystem.current.IsPointerOverGameObject() && Preferences.instance.gameState == Preferences.GameState.Running)
        {
            //Ray to be cast from the mouse outward
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            //Cast the ray onto "layer"
            if (Physics.Raycast(ray, out hitInfo, 100f, layer))
            {
                //The node with which the ray intersected
                GridNode currentNode = hitInfo.collider.gameObject.GetComponent<GridNode>();

                //When the player clicks the left mouse button
                if (Input.GetMouseButtonDown(0))
                {
                    //If the node is not occupied...
                    if (currentNode.isOccupied)
                    {
                        //Display the upgrade UI
                        ToggleUpgradeTowers(true);
                        //Set the tower occupying the node as the selected tower
                        SelectTower(currentNode.tower);
                    }
                    else
                        //Disable the upgrade UI
                        ToggleUpgradeTowers(false);
                }
            }
        }

        //If there is a tower selected, and the UI is enabled, update stat values.
        if (tower && isEnabled)
        {
            UpdateTowerStats();
        }

        //If the game state is not set to running, disable the upgrade UI
        if (Preferences.instance.gameState != Preferences.GameState.Running)
            ToggleUpgradeTowers(false);
    }

    //Select towerObj as tower
    void SelectTower(GameObject towerObj)
    {
        //If there is currently a selected tower or towerObj is null..
        if (tower || towerObj == null)
            //Reset the tower's colour
            ColourTower(tower);

        //Set towerobj as the currently selected tower
        tower = towerObj;

        //If a tower is currently selected...
        if (tower)
        {
            //Tint the tower's material with selectColour
            ColourTower(tower, selectColour);

            //Update the details of the tower in the UI
            UpdateTowerDetails();
        }
    }

    void UpdateTowerDetails()
    {
        towerStats = tower.GetComponent<TowerStats>();

        //Load a sprite with the same name as the tower, within "Resources/Sprites/"
        towerSprite = Resources.Load<Sprite>("Sprites/" + tower.name);

        //Set the name text to the name of the tower
        nameText.text = tower.name;
        //Set the tower image to the towerSprite
        towerImage.sprite = towerSprite;
    }

    void UpdateTowerStats()
    {
        if (towerStats)
        {
            //Get and store values from the selected tower's TowerStats
            int currentHealth = towerStats.currentHealth;
            int maxHealth = towerStats.maxHealth;

            int currentXP = towerStats.currentXP;
            int levelXP = towerStats.levelXP;

            int currentLevel = towerStats.currentLevel;
            int maxLevel = towerStats.maxLevel;

            //Change the stat sliders and text to the values of the above variables
            healthSlider.value = Mathf.Lerp(healthSlider.value, (float)currentHealth / maxHealth, barAnimSmoothness);
            healthText.text = string.Format(healthTextString, currentHealth, maxHealth);

            xpSlider.value = Mathf.Lerp(xpSlider.value, (float)currentXP / levelXP, barAnimSmoothness);
            xpText.text = string.Format(xpTextString, currentXP, levelXP);

            levelSlider.value = Mathf.Lerp(levelSlider.value, (float)currentLevel / maxLevel, barAnimSmoothness);
            levelText.text = string.Format(levelTextString, currentLevel, maxLevel);
        }
    }

    void ToggleUpgradeTowers(bool enabled)
    {
        isEnabled = enabled;

        //If there is currently a tower selected, and the UI is disabled, deselect it
        if(tower && !isEnabled)
            SelectTower(null);

        //Set the UI to the desired active state
        upgradeUI.SetActive(isEnabled);
    }

    #region colouring_towers
    void ColourTower(GameObject towerObj, Color colour)
    {
        //Finds all the mesh renderers in the model (for appearance changes without affecting the material)
        Component[] comps = towerObj.GetComponentsInChildren<MeshRenderer>();

        //Tint the object green
        foreach (Component comp in comps)
        {
            originalColours.Add(comp.renderer.material.color);

            comp.renderer.material.color += colour;
        }
    }

    void ColourTower(GameObject towerObj)
    {
        //Finds all the mesh renderers in the model (for appearance changes without affecting the material)
        Component[] comps = towerObj.GetComponentsInChildren<MeshRenderer>();

        //Set the object's colours back to their original
        for (int i = 0; i < comps.Length; i++)
        {
            comps[i].renderer.material.color = originalColours[i];
        }

        //Reset the original colours list
        originalColours = new List<Color>();
    }
    #endregion

    public void RepairTower()
    {
        int cost = towerStats.resourcesCost / 2;

        if (playerStats.currentResources >= cost && towerStats.currentHealth < towerStats.maxHealth)
        {
            playerStats.RemoveResources(cost);

            towerStats.AddHealth(towerStats.maxHealth);
        }
    }
}
