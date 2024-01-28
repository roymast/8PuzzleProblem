using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GridTileSwitcher : MonoBehaviour
{
    [SerializeField] GridManager gridManager;
    public static System.Action OnSwitchSucceeded;

    private void Start()
    {        
        Tile.OnTilePress += TrySwitchTiles;
    }
    private void OnDisable()
    {
        Tile.OnTilePress -= TrySwitchTiles;
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            gridManager.PrintGrid();
        }
    }

    private void TrySwitchTiles(Vector2 tilePos)
    {
        int x = (int)tilePos.x;
        int y = (int)tilePos.y;        
        int width = gridManager.Grid.GetLength(0);
        int height = gridManager.Grid.GetLength(1);
        
        if (x + 1 < width && gridManager.Grid[x + 1, y].IsEmpty)
            Switch(new Vector2(x, y), new Vector2(x + 1, y));
        else if (x > 0 && gridManager.Grid[x - 1, y].IsEmpty)
            Switch(new Vector2(x, y), new Vector2(x - 1, y));
        else if (y + 1 < height && gridManager.Grid[x, y + 1].IsEmpty)
            Switch(new Vector2(x, y), new Vector2(x, y + 1));
        else if (y > 0 && gridManager.Grid[x, y - 1].IsEmpty)
            Switch(new Vector2(x, y), new Vector2(x, y - 1));        
    }
    public void Switch(Vector2 tile1, Vector2 tile2)
    {   
        //Move UI
        Vector2 tempPos = gridManager.Grid[(int)tile1.x, (int)tile1.y].transform.position;
        gridManager.Grid[(int)tile1.x, (int)tile1.y].transform.position = gridManager.Grid[(int)tile2.x, (int)tile2.y].transform.position;
        gridManager.Grid[(int)tile2.x, (int)tile2.y].transform.position = tempPos;

        //Update in the tiles
        gridManager.Grid[(int)tile1.x, (int)tile1.y].UpdatePos(tile2);
        gridManager.Grid[(int)tile2.x, (int)tile2.y].UpdatePos(tile1);

        //Update in the grid
        Tile temp = gridManager.Grid[(int)tile1.x, (int)tile1.y];
        gridManager.Grid[(int)tile1.x, (int)tile1.y] = gridManager.Grid[(int)tile2.x, (int)tile2.y];
        gridManager.Grid[(int)tile2.x, (int)tile2.y] = temp;
        OnSwitchSucceeded?.Invoke();        
    }
}
