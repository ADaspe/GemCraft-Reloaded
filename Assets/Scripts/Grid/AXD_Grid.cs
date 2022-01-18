using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AXD_Grid : MonoBehaviour
{
    [SerializeField]
    private int height, width = 10;
    [SerializeField]
    private float gridSpaceSize = 5f;

    [SerializeField] private GameObject gridCellPrefab;
    
    private GameObject[,] gameGrid;

    private void Start()
    {
        CreateGrid();
    }
    
    //Creates the grid when called
    private void CreateGrid()
    {

        if (gridCellPrefab == null)
        {
            Debug.LogError("ERROR: GridCellPrefab is empty");
            return;
        }

        gameGrid = new GameObject[width, height];
        //Make the grid
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                gameGrid[i, j] = Instantiate(gridCellPrefab, new Vector3(i * gridSpaceSize,0, j * gridSpaceSize),
                    Quaternion.identity);
                gameGrid[i,j].GetComponent<AXD_GridCell>().SetPosition(i,j);
                gameGrid[i, j].transform.parent = transform;
                gameGrid[i, j].gameObject.name = "Grid cell (" + i.ToString() + "," + j.ToString() + ")";
            }
        }
    }

    //Gets the grid position from world position
    public Vector2Int GetGridPosFromWorld(Vector3 worldPosition)
    {
        int x = Mathf.FloorToInt(worldPosition.x / gridSpaceSize);
        int y = Mathf.FloorToInt(worldPosition.z / gridSpaceSize);
        x = Mathf.Clamp(x, 0, width);
        y = Mathf.Clamp(y, 0, height);
        return new Vector2Int(x, y);
    }
    
    // gets the world position of a grid position
    public Vector3 GetWorldPosFromGridPos(Vector2Int gridPos)
    {
        float x = gridPos.x * gridSpaceSize;
        float y = gridPos.y * gridSpaceSize;

        return new Vector3(x, 0, y);
    }

}
