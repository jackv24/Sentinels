using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlaceTowers : MonoBehaviour
{
    public GameObject placementUI;
    public GameObject grid;

    //Can the player place towers?
    public bool isEnabled = false;

    public Color selectColour;

    //The layer on which towers can be placed
    public LayerMask layer;

    public GameObject towerTogglePrefab;
    public Transform toggleList;

    //The tower prefab to instantiate
    public GameObject[] towers;
    private int towerIndex = 0;

    private GridNode currentNode;

    //The current tower, to follow the mouse cursor over the grid for placement
    private GameObject currentTower;

    private PlayerStats playerStats;

    void Start()
    {
        PopulateTowerList();

        placementUI.SetActive(isEnabled);
        grid.SetActive(isEnabled);

        playerStats = GameObject.Find("Player").GetComponent<PlayerStats>();
    }

    void Update()
    {
        if (Input.GetButtonDown("ToggleBuild") && Preferences.instance.gameState != Preferences.GameState.Paused)
            ToggleBuild();

        if (isEnabled && Input.GetButtonDown("Cancel"))
            ToggleBuild();

        //If enabled, and If a tower is selected, and If the mouse isn't over a GUI element...
        if (isEnabled && currentTower)
        {
            //Ray to be cast from the mouse outward
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(ray, out hitInfo, 100f, layer))
            {
                currentNode = hitInfo.collider.gameObject.GetComponent<GridNode>();

                //If the node is not occupied...
                if (!currentNode.isOccupied && !EventSystem.current.IsPointerOverGameObject())
                {
                    //Set the position of the current tower to the grid tile position
                    currentTower.transform.position = hitInfo.transform.position;

                    //When the player clicks the left mouse button, and there is enough resources...
                    if (Input.GetMouseButton(0) && playerStats.currentResources >= towers[towerIndex].GetComponent<TowerStats>().resourcesCost)
                    {
                        //Place the tower
                        PlaceTower(towers[towerIndex], hitInfo.transform.position, towers[towerIndex].GetComponent<TowerStats>().resourcesCost);

                        //Move the current tower out of view
                        currentTower.transform.position = Vector3.up * 100;
                    }
                }
            }
        }
    }

    void PopulateTowerList()
    {
        for(int i = 0; i < towers.Length; i++)
        {
            GameObject buttonObj = (GameObject)Instantiate(towerTogglePrefab);
            buttonObj.transform.SetParent(toggleList, false);
            buttonObj.name = towers[i].name + "Toggle";

            RectTransform rect = buttonObj.GetComponent<RectTransform>();
            rect.localPosition = new Vector3(0, rect.rect.height * -i, 0);

            Text text = buttonObj.transform.FindChild("Label").GetComponent<Text>();
            text.text = string.Format(text.text, towers[i].GetComponent<TowerStats>().resourcesCost);

            Image image = buttonObj.transform.FindChild("Image").GetComponent<Image>();
            image.sprite = Resources.Load<Sprite>("Sprites/" + towers[i].name);

            Button button = buttonObj.GetComponent<Button>();
            button.onClick.RemoveAllListeners();

            int j = i;
            button.onClick.AddListener(() => ChangeCurrentTower(j));
        }
    }

    void ToggleBuild()
    {
        if (isEnabled)
        {
            isEnabled = false;
            Preferences.instance.gameState = Preferences.GameState.Running;
        }
        else
        {
            isEnabled = true;
            Preferences.instance.gameState = Preferences.GameState.Menu;
        }

        if (isEnabled)
            ChangeCurrentTower(towerIndex);
        else
            ChangeCurrentTower(-1);

        placementUI.SetActive(isEnabled);
        grid.SetActive(isEnabled);
    }

    //Changes the currently selected tower (usually called from the GUI)
    public void ChangeCurrentTower(int index)
    {
        Vector3 pos = Vector3.up * 100;

        //If a tower is already selected, destroy it (the placement dummy)
        if (currentTower)
        {
            pos = currentTower.transform.position;
            Destroy(currentTower);
        }

        //If there is a prefab with that index...
        if (index < towers.Length && index >= 0)
        {
            //Set the current tower index to that index
            towerIndex = index;

            //Spawn the placement tower
            currentTower = (GameObject)Instantiate(towers[towerIndex], pos, Quaternion.identity);
            //Disable script - this is a placement dummy
            currentTower.GetComponent<Turret>().enabled = false;

            //Finds all the mesh renderers in the model (for appearance changes without affecting the material)
            Component[] comps = currentTower.GetComponentsInChildren<MeshRenderer>();

            //Tint the object green
            foreach (Component comp in comps)
            {
                comp.renderer.material.color += selectColour;
            }
        }
    }

    //Spawns the specified tower at a specified position
    void PlaceTower(GameObject towerPrefab, Vector3 position, int cost)
    {
        //Spawns the tower
        GameObject tower = (GameObject)Instantiate(towerPrefab, position, Quaternion.identity);
        tower.name = towerPrefab.name;

        //Creates a reference to a gameobject
        GameObject towers;

        //If the gameobject doesn't exist, create it
        if (!GameObject.Find("Towers"))
            towers = new GameObject("Towers");
        //If the gameobject does exist, set it's reference
        else
            towers = GameObject.Find("Towers");

        //Parent the tower to the gameobject (for a clean heirarchy)
        tower.transform.parent = towers.transform;

        //Set the node to occupied
        currentNode.tower = tower;

        playerStats.RemoveResources(cost);
    }
}