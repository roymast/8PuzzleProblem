using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{
    static GameManager gameManager;
    public static Vector2 tileSize;

    [SerializeField] private int value;
    [SerializeField] private Vector2 pos;
    [SerializeField] private Vector2 correctPos;
    public bool IsEmpty { get { return value == 0; } }
    public int Value { get { return value; } }
    [SerializeField] TextMeshPro TileText;
    [SerializeField] SpriteRenderer Rect;
    [SerializeField] SpriteRenderer Fill;
    [SerializeField] SpriteRenderer CorrectPosIndicator;

    public static System.Action<Vector2> OnTilePress;

    private void OnMouseEnter()
    {
        if (!IsEmpty)
        {
            if (gameManager.IsGameRunning && !gameManager.IsGameEnd)
            {
                OnTilePress?.Invoke(pos);
            }
        }
    }
    public void Init(int val, Vector2 InitPos, Vector2 corrctpos, TileViewData tileViewData)
    {
        if (gameManager == null)
            gameManager = FindObjectOfType<GameManager>();
        value = val;
        pos = new Vector2(InitPos.x, InitPos.y);
        this.correctPos = corrctpos;        
        UpdateCorrectPosIndicator();
        TileText.text = val == 0 ? "" : val.ToString();

        if (tileViewData != null)
        {
            Fill.color = tileViewData.FillColor;
            Rect.color = tileViewData.RectColor;
            TileText.color = tileViewData.TextColor;
        }        
    }
    public void UpdatePos(Vector2 newPos)
    {
        pos = newPos;
        UpdateCorrectPosIndicator();
    }    
    public void UpdateCorrectPosIndicator()
    {
        CorrectPosIndicator.gameObject.SetActive(pos == correctPos);
    }
    
}
