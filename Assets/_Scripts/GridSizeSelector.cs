using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class GridSizeSelector : MonoBehaviour
{
    public static int GridSize = 3;
    public TextMeshProUGUI GridSizeText;
    private void Start()
    {
        if(GridSizeText != null)
            GridSizeText.text = GridSize.ToString();
    }
    public void IncreaseGrid()
    {
        GridSize++;
        GridSizeText.text = GridSize.ToString();
    }
    public void DecreaseGrid()
    {
        if(GridSize > 3)
            GridSize--;
        GridSizeText.text = GridSize.ToString();
    }
}
