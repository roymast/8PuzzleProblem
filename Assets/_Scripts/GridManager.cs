using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public Tile[,] Grid;
    [SerializeField] int gridSize;
    
    [SerializeField] PuzzleGridGenerator gridGenerator;
    [SerializeField] GridTileSwitcher tileSwitcher;
    [SerializeField] GameObject GameOverScreen;
    // Start is called before the first frame update
    void Start()
    {
        gridSize = GridSizeSelector.GridSize;
        tileSwitcher.OnSwitchSucceeded += CheckForGameOver;
        Grid = gridGenerator.Generate(gridSize);
        Debug.Log($"Solved? {IsSolved()}");
    }
    public void PrintGrid()
    {
        string s = "\n";
        for (int x = 0; x < Grid.GetLength(0); x++)
        {            
            for (int y = 0; y < Grid.GetLength(1); y++)
            {
                s += Grid[x, y].Value + " ";
            }
            s += "\n";
        }
        Debug.Log(s);
    }
    public void CheckForGameOver()
    {
        if (!IsSolved())
            return;
        GameOverScreen.SetActive(true);
    }

    public bool IsSolved()
    {
        if (!Grid[Grid.GetLength(1) - 1, Grid.GetLength(0) - 1].IsEmpty)
            return false;

        for (int y = 0; y < Grid.GetLength(1); y++)
        {
            for (int x = 0; x < Grid.GetLength(0); x++)
            {
                if (y == Grid.GetLength(1) - 1 && x == Grid.GetLength(0) - 2)
                    return true;
                if (x == Grid.GetLength(0) - 1)
                {
                    if (Grid[y, x].Value > Grid[y + 1, 0].Value)
                        return false;
                }
                else
                {
                    if (Grid[y, x].Value > Grid[y, x + 1].Value)
                        return false;
                }
            }
        }
        return true;
    }
}
