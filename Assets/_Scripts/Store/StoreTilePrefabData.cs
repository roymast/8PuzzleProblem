using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class StoreTilePrefabData : MonoBehaviour
{
    [SerializeField] Image Rect;
    [SerializeField] Image Fill;
    [SerializeField] TextMeshProUGUI TileNumber;

    public TextMeshProUGUI NameLable;
    [SerializeField] TextMeshProUGUI UseOrBuyLable;

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
