using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI;
using UnityEngine.Purchasing;

public class GridSizeSelector : MonoBehaviour
{
    public int MaxGrid = 13;
    public int MinGrid = 3;

    public static int GridSize = 3;
    public TextMeshProUGUI GridSizeText;
    public Button IncButton;
    public Button DecButton;
    private void Start()
    {
        UpdateUI();
    }
    public void IncreaseGrid()
    {
        if (GridSize < MaxGrid)
            GridSize++;
        UpdateUI();
    }
    public void DecreaseGrid()
    {
        if (GridSize > MinGrid)
            GridSize--;
        UpdateUI();
    }
    void UpdateUI()
    {
        if (GridSizeText != null)
            UpdateText();
        if (IncButton != null && DecButton != null)
            UpdateInteractable();
    }
    void UpdateText()
    {
        GridSizeText.text = GridSize.ToString();
    }
    void UpdateInteractable()
    {
        DecButton.interactable = GridSize > MinGrid;
        IncButton.interactable = GridSize < MaxGrid;
    }
}
