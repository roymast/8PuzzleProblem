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

    // Start is called before the first frame update
    void Start()
    {
        StoreTilePrefabData.BuyButtonPressed += TryBuying;
        StoreTilePrefabData.UseButtonPressed += TryUseTile;

        PlayerPrefs.DeleteAll();        
        UpdatePlayerPoints();
        string storeItemsBought = PlayerData.StoreItemsBought;
        string[] myStoreItemsSplit = storeItemsBought.Split(' ');
        for (int i = 0; i < myStoreItemsSplit.Length; i++)
        {
            Debug.Log(myStoreItemsSplit[i]);
        }        
        string storeTileUsing = PlayerData.CurrentStoreTileItem;
        for (int i = 0; i < allPrefabs.Length; i++)
        {
            StoreTilePrefabData current = Instantiate(allPrefabs[i], container);
            bool isBought = Array.IndexOf(myStoreItemsSplit, current.NameLable.text) >= 0;

            StoreTilePrefabData.State state;
            if (!isBought)
                state = StoreTilePrefabData.State.NeedToBuy;
            else if (storeTileUsing != current.NameLable.text)
                state = StoreTilePrefabData.State.CanUse;
            else
            {
                state = StoreTilePrefabData.State.Using;
                selected = current;
            }

            current.Init(state);
        }
    }   
    public void TryUseTile(StoreTilePrefabData tileToSelect)
    {
        if (tileToSelect.CurrentState == StoreTilePrefabData.State.Using)
            return;
        if (tileToSelect.CurrentState == StoreTilePrefabData.State.NeedToBuy)
            return;

        selected.SetState(StoreTilePrefabData.State.CanUse);
        tileToSelect.SetState(StoreTilePrefabData.State.Using);

        selected = tileToSelect;
        PlayerData.CurrentStoreTileItem = tileToSelect.NameLable.text;
    }
    public void TryBuying(StoreTilePrefabData tileToBuy)
    {        
        if (PlayerData.ReducePoints(tileToBuy.price))
        {            
            selected.SetState(StoreTilePrefabData.State.CanUse);
            tileToBuy.SetState(StoreTilePrefabData.State.Using);

            selected = tileToBuy;
            PlayerData.StoreItemsBought += " " + tileToBuy.NameLable.text;
            UpdatePlayerPoints();
        }
    }
    void UpdatePlayerPoints()
    {        
        playerPoints.text = "Points: " + PlayerData.PlayerPoints;
    }
}
