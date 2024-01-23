using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class StoreManager : MonoBehaviour
{
    [SerializeField] Transform container;
    [SerializeField] TextMeshProUGUI playerPoints;
    [SerializeField] StoreTilePrefabData selected;

    [SerializeField] StoreTilePrefabData[] allPrefabs;
    TileViewData currentViewData;
    // Start is called before the first frame update
    void Start()
    {
        currentViewData = new TileViewData();
        StoreTilePrefabData.BuyButtonPressed += TryBuying;
        StoreTilePrefabData.UseButtonPressed += TryUseTile;

        PlayerPrefs.DeleteAll();
        UpdatePlayerPoints();
        string storeItemsBought = PlayerData.StoreItemsBought;
        string[] myStoreItemsSplit = storeItemsBought.Split(' ');        
        string storeTileUsing = PlayerData.CurrentStoreTileItem;        
        for (int i = 0; i < allPrefabs.Length; i++)
        {
            StoreTilePrefabData current = Instantiate(allPrefabs[i], container);
            bool isBought = Array.IndexOf(myStoreItemsSplit, current.NameLable.text.Replace(' ', '_')) >= 0;

            StoreTilePrefabData.State state;
            if (!isBought)
                state = StoreTilePrefabData.State.NeedToBuy;
            else if (storeTileUsing != current.NameLable.text.Replace(' ', '_'))
                state = StoreTilePrefabData.State.CanUse;
            else
            {
                state = StoreTilePrefabData.State.Using;
                selected = current;
            }

            current.Init(state);
        }
        if (selected == null)
        {
            selected = allPrefabs[0];
            selected.Init(StoreTilePrefabData.State.Using);            
        }
    }
    private void OnDestroy()
    {
        StoreTilePrefabData.BuyButtonPressed -= TryBuying;
        StoreTilePrefabData.UseButtonPressed -= TryUseTile;
    }
    public void TryUseTile(StoreTilePrefabData tileToSelect)
    {
        if (tileToSelect.CurrentState == StoreTilePrefabData.State.Using)
            return;
        if (tileToSelect.CurrentState == StoreTilePrefabData.State.NeedToBuy)
            return;

        UseTile(tileToSelect);
    }
    public void TryBuying(StoreTilePrefabData tileToBuy)
    {        
        if (PlayerData.ReducePoints(tileToBuy.price))
        {                        
            PlayerData.StoreItemsBought += " " + tileToBuy.NameLable.text.Replace(' ', '_');
            UpdatePlayerPoints();
            UseTile(tileToBuy);
        }
    }
    void UseTile(StoreTilePrefabData tileToSelect)
    {
        selected.SetState(StoreTilePrefabData.State.CanUse);
        tileToSelect.SetState(StoreTilePrefabData.State.Using);

        selected = tileToSelect;
        UpdateTileViewData();
        PlayerData.CurrentStoreTileItem = tileToSelect.NameLable.text.Replace(' ', '_');
    }
    void UpdateTileViewData()
    {
        currentViewData.FillColor = selected.Fill.color;
        currentViewData.RectColor = selected.Rect.color;
        currentViewData.TextColor = selected.TileNumber.color;             
        PlayerData.CurrentTileData = currentViewData;        
    }
    void UpdatePlayerPoints()
    {        
        playerPoints.text = "Points: " + PlayerData.PlayerPoints;
    }
}
