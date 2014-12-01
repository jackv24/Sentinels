using UnityEngine;
using System.Collections;

public class GenerateGrid : MonoBehaviour
{
    //The node prefab to be instantiated in a grid
    public GameObject nodePrefab;
    //The size of the grid (in node amounts)
    public Vector2 size;
    //The layer for rays to be cast to determine node height
    public LayerMask layer;

    //Should a grid be generated?
    public bool generate = false;

    void Start()
    {
        //If a grid is to be generated...
        if (generate)
        {
            //Get the size of the node's box collider
            float sizeX = nodePrefab.transform.localScale.x;
            float sizeY = nodePrefab.transform.localScale.z;

            //Create the grid. For every row...
            for (int i = 0; i < size.x; i++)
            {
                //Generate a column
                for (int j = 0; j < size.y; j++)
                {
                    //Create the vector at which the node should be placed
                    Vector3 placeVector = new Vector3(i * sizeX + transform.position.x, 500, j * sizeY + transform.position.z);

                    RaycastHit hitInfo;
                    //Cast a ray down onto layer
                    if (Physics.Raycast(placeVector, -Vector3.up, out hitInfo, 1000, layer))
                    {
                        //Placement height is where ray hit
                        placeVector.y = hitInfo.point.y;

                        //Instantiate node
                        GameObject obj = (GameObject)Instantiate(nodePrefab, placeVector, Quaternion.identity);
                        //Set node as child of grid
                        obj.transform.parent = transform;
                    }
                }
            }
        }
    }
}
