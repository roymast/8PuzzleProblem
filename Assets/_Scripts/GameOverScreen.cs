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
    [SerializeField] GameObject NewTimeBestGO;
    [SerializeField] GameObject NewMovesBestGO;
    [SerializeField] Canvas GameOverCanvas;

    public void OnGameOver()
    {
        int time = (int)timer.GetTime();
        int moves = moveCounter.GetMoveCount();
        GameOverCanvas.gameObject.SetActive(true);
        TimerText.text = time.ToString();
        PointsText.text = moves.ToString();
        bool isNewTimeBest = PlayerData.BestTimeVal > time || PlayerData.BestTimeVal == 0;
        bool isNewMovesBest = PlayerData.BestMovesVal > moves || PlayerData.BestMovesVal == 0;
        NewTimeBestGO.SetActive(isNewTimeBest);
        NewMovesBestGO.SetActive(isNewMovesBest);
        PlayerData.UpdateBestMoves(time, moves);
        PlayerData.UpdateBestTime(time, moves);
    }
}
