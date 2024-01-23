using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCounter : MonoBehaviour
{    
    int moveCount;
    // Start is called before the first frame update
    void Start()
    {
        GridTileSwitcher.OnSwitchSucceeded += OnSwitchSucceeded;
    }

    private void OnDestroy()
    {
        GridTileSwitcher.OnSwitchSucceeded -= OnSwitchSucceeded;
    }
    void OnSwitchSucceeded()
    {
        moveCount++;
    }
    public int GetMoveCount()
    {
        return moveCount;
    }
}
