using UnityEngine;
using System.Collections;

public class PlaceTowers : MonoBehaviour
{
    //The layer on which towers can be placed
    public LayerMask layer;

    //The tower prefab to instantiate
    public GameObject towerPrefab;
    //The current tower, to follow the mouse cursor over the grid for placement
    private GameObject currentTower;

    void Start()
    {
        //Spawns a single tower, and sets it as the current (for testing)
        currentTower = (GameObject)Instantiate(towerPrefab, Vector3.up * 100, Quaternion.identity);
    }

    void Update()
    {
        //Ray to be cast from the mouse outward
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, 100f, layer))
        {
            GridNode node = hitInfo.collider.gameObject.GetComponent<GridNode>();

            //If the node is not occupied...
            if (!node.isOccupied)
            {
                //Set the position of the current tower to the grid tile position
                currentTower.transform.position = hitInfo.transform.position;

                //When the player clicks the left mouse button...
                if (Input.GetMouseButton(0))
                {
                    //Set the node to occupied
                    node.isOccupied = true;
                    //Place the tower
                    PlaceTower(towerPrefab, hitInfo.transform.position);

                    //Move the current tower out of view
                    currentTower.transform.position = Vector3.up * 100;
                }
            }
        }
    }

    void PlaceTower(GameObject towerPrefab, Vector3 position)
    {
        GameObject tower = (GameObject)Instantiate(towerPrefab, position, Quaternion.identity);

        GameObject towers;

        if (!GameObject.Find("Towers"))
            towers = new GameObject("Towers");
        else
            towers = GameObject.Find("Towers");

        tower.transform.parent = towers.transform;
    }
}
