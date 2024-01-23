using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class StoreTilePrefabData : MonoBehaviour
{
    public Image Rect;
    public Image Fill;
    public TextMeshProUGUI TileNumber;

    public TextMeshProUGUI NameLable;
    [SerializeField] TextMeshProUGUI UseOrBuyLable;

    public TileViewData tileViewData;

    public static System.Action<StoreTilePrefabData> UseButtonPressed;
    public static System.Action<StoreTilePrefabData> BuyButtonPressed;
    public enum State
    {
        CanUse,
        Using,
        NeedToBuy
    };
    public State CurrentState;
    public int price;

    public void Init(State initState)
    {
        CurrentState = initState;

        tileViewData.FillColor = Fill.color;
        tileViewData.RectColor= Rect.color;
        tileViewData.TextColor = TileNumber.color;

        SetButtonText(initState);
    }    
    public void OnButtonPressed()
    {
        if(CurrentState == State.CanUse)        
            UseButtonPressed?.Invoke(this);        
        else if (CurrentState == State.NeedToBuy)        
            BuyButtonPressed?.Invoke(this);        
    }
    public void SetState(State state)
    {
        CurrentState = state;
        SetButtonText(state);
    }    
    private void SetButtonText(State initState)
    {
        switch (initState)
        {
            case State.CanUse:
                UseOrBuyLable.text = "Use";
                break;
            case State.Using:
                UseOrBuyLable.text = "Using";
                break;
            case State.NeedToBuy:
                UseOrBuyLable.text = price.ToString() + "P";
                break;
        }
    }
}
