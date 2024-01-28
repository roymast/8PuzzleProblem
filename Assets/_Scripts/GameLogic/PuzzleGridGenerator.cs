using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;

public class PuzzleGridGenerator : MonoBehaviour 
{    
    [SerializeField] Tile tilePrefab;
    [SerializeField] Tile[,] grid;
    int _gridSize;    
    
    // Start is called before the first frame update
    public Tile[,] Generate(int gridSize)
    {
        TileViewData tileViewData = PlayerData.CurrentTileData;
        _gridSize = gridSize;
        int[] lst = GridLogic.GetGrid(gridSize);
        grid = new Tile[gridSize, gridSize];
        SetTileSize();
        float tileSizeX = (Tile.tileSize.x / gridSize)*0.8f;
        float tileSizeY = (Tile.tileSize.y / gridSize)*0.8f;
        for (int x = 0; x < grid.GetLength(0); x++)
        {
            for (int y = 0; y < grid.GetLength(1); y++)
            {
                Tile newTile = Instantiate(tilePrefab, transform);
                newTile.transform.localScale = new Vector2(tileSizeX, tileSizeY);
                newTile.transform.position = new Vector2(y * tileSizeX, -x * tileSizeY);
                int val = lst[x * gridSize + y];
                newTile.Init(val, new Vector2(x, y), GetCorrectPos(val), tileViewData);
                grid[x, y] = newTile;
            }
        }
        
        Camera.main.transform.position = new Vector3(((gridSize-1) / 2.0f) * tileSizeX, -((gridSize-1) / 2.0f) * tileSizeY, -10);
        return grid;
    }   
    public Vector2 GetCorrectPos(int val)
    {
        if (val == 0)
            return new Vector2(_gridSize - 1, _gridSize - 1);
        return new Vector2((val+1) / _gridSize, (val+1) % _gridSize);
    }
    public void SetTileSize()
    {        
        float planeToCameraDistance = Vector3.Distance(gameObject.transform.position, Camera.main.transform.position);
        float planeHeightScale = (2.0f * Mathf.Tan(0.5f * Camera.main.fieldOfView * Mathf.Deg2Rad) * planeToCameraDistance);
        float planeWidthScale = planeHeightScale * Camera.main.aspect;
        Tile.tileSize = new Vector2 (planeWidthScale, planeHeightScale);
    }    
}
