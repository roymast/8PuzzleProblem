using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScreen : MonoBehaviour
{
    //[SerializeField] Timer
    //[SerializeField] Points    
    //[SerializeField] TimerText
    //[SerializeField] PointsText
    [SerializeField] Canvas GameOverCanvas;

    public void OnGameOver()
    {
        GameOverCanvas.gameObject.SetActive(true);
        //InsertData
    }    
}
