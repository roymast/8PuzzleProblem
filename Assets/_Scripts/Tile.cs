using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tile : MonoBehaviour
{
    public static Vector2 tileSize;    

    [SerializeField] private int value;
    [SerializeField] private Vector2 pos;
    public bool IsEmpty { get { return value == 0; } }
    public int Value { get { return value; } }
    [SerializeField] TextMeshPro TileText;

    public static System.Action<Vector2> OnTilePress;
    
    private void OnMouseEnter()
    {
        if (!IsEmpty)
            OnTilePress?.Invoke(pos);
    }    
    public void Init(int val, int x, int y)
    {
        value = val;
        pos = new Vector2(x, y);
        TileText.text = val == 0 ? "":val.ToString();
    }
    public void UpdatePos(Vector2 newPos)
    {
        pos = newPos;
    }
}