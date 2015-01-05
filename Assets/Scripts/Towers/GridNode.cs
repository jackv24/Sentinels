using UnityEngine;
using System.Collections;

public class GridNode : MonoBehaviour
{
    public GameObject tower;

    //Is the node occupied?
    public bool isOccupied = false;

    void Update()
    {
        if (tower)
            isOccupied = true;
        else
            isOccupied = false;
    }
}
