using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] Timer timer;
    [SerializeField] MoveCounter moveCounter;
    [SerializeField] TextMeshProUGUI TimerText;
    [SerializeField] TextMeshProUGUI PointsText;
    [SerializeField] Canvas GameOverCanvas;

    public void OnGameOver()
    {
        GameOverCanvas.gameObject.SetActive(true);
        TimerText.text = ((int)timer.GetTime()).ToString();
        PointsText.text = (moveCounter.GetMoveCount()).ToString();
        
        //InsertData
    }    
}
