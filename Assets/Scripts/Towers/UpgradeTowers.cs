using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UpgradeTowers : MonoBehaviour
{
    public GameObject upgradeUI;

    public LayerMask layer;

    public bool isEnabled;

    private GameObject tower;

    private TowerStats towerStats;

    public Text nameText;

    public Image towerImage;
    private Sprite towerSprite;

    public Slider healthSlider;
    public Text healthText;
    private string healthTextString;

    public Slider xpSlider;
    public Text xpText;
    private string xpTextString;

    public Slider levelSlider;
    public Text levelText;
    private string levelTextString;

    public Text nextLevelText;

    public float barAnimSmoothness = 0.25f;

    void Start()
    {
        healthTextString = healthText.text;
        xpTextString = xpText.text;
        levelTextString = levelText.text;

        ToggleUpgradeTowers(false);
    }

    void Update()
    {
        if (!EventSystem.current.IsPointerOverGameObject() && Preferences.instance.gameState == Preferences.GameState.Running)
        {
            //Ray to be cast from the mouse outward
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(ray, out hitInfo, 100f, layer))
            {
                GridNode currentNode = hitInfo.collider.gameObject.GetComponent<GridNode>();

                //When the player clicks the left mouse button
                if (Input.GetMouseButtonDown(0))
                {
                    //If the node is not occupied...
                    if (currentNode.isOccupied)
                    {
                        ToggleUpgradeTowers(true);
                        SelectTower(currentNode.tower);
                    }
                    else
                        ToggleUpgradeTowers(false);
                }
            }
        }

        if (tower && isEnabled)
        {
            UpdateTowerStats();
        }

        if (Preferences.instance.gameState != Preferences.GameState.Running)
            ToggleUpgradeTowers(false);
    }

    void SelectTower(GameObject towerObj)
    {
        tower = towerObj;

        UpdateTowerDetails();
    }

    void UpdateTowerDetails()
    {
        towerStats = tower.GetComponent<TowerStats>();

        towerSprite = Resources.Load<Sprite>("Sprites/" + tower.name);

        nameText.text = tower.name;
        towerImage.sprite = towerSprite;
    }

    void UpdateTowerStats()
    {
        if (towerStats)
        {
            int currentHealth = towerStats.currentHealth;
            int maxHealth = towerStats.maxHealth;

            int currentXP = towerStats.currentXP;
            int levelXP = towerStats.levelXP;

            int currentLevel = towerStats.currentLevel;
            int maxLevel = towerStats.maxLevel;

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

        upgradeUI.SetActive(enabled);
    }
}
