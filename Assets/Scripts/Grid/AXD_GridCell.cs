using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AXD_GridCell : MonoBehaviour
{
    private int posX, posY;
    
    // Saves a reference to the gameobject that gets placed on this cell
    public GameObject objectInThisCell = null;

    public bool isOccupied = false;
    // Start is called before the first frame update
    
    //Set the position of the grid cell on the grid
    public void SetPosition(int x, int y)
    {
        posX = x;
        posY = y;
    }
    
    //get the position of the grid cell on the grid
    public Vector2Int GetPosition()
    {
        return new Vector2Int(posX, posY);
    }

}
