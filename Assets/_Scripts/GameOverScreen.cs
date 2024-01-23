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
    [SerializeField] TextMeshProUGUI MovesText;
    [SerializeField] TextMeshProUGUI PointsAdded;
    [SerializeField] GameObject NewTimeBestGO;
    [SerializeField] GameObject NewMovesBestGO;
    [SerializeField] Canvas GameOverCanvas;
    
    public void OnGameOver()
    {
        int time = (int)timer.GetTime();
        int moves = moveCounter.GetMoveCount();
        GameOverCanvas.gameObject.SetActive(true);
        StartCoroutine(AnimateIncVal(TimerText, 0, time));
        StartCoroutine(AnimateIncVal(MovesText, 0, moves));
        StartCoroutine(AnimatePointsInc(PointsAdded, 0, GridSizeSelector.GridSize));

        bool isNewTimeBest = PlayerData.BestTimeVal > time || PlayerData.BestTimeVal == 0;
        bool isNewMovesBest = PlayerData.BestMovesVal > moves || PlayerData.BestMovesVal == 0;
        NewTimeBestGO.SetActive(isNewTimeBest);
        NewMovesBestGO.SetActive(isNewMovesBest);
        PlayerData.UpdateBestMoves(time, moves);
        PlayerData.UpdateBestTime(time, moves);
        PlayerData.AddPoints(GridSizeSelector.GridSize);
    }
    IEnumerator AnimateIncVal(TextMeshProUGUI text, int startVal, int endVal)
    {
        for (int i = 0; i <= endVal - startVal; i++)
        {
            text.text = (startVal + i).ToString();
            yield return new WaitForSeconds(3.0f / (endVal - startVal));
        }
        text.text = endVal.ToString();
    }
    IEnumerator AnimatePointsInc(TextMeshProUGUI text, int startVal, int endVal)
    {
        for (int i = 0; i <= GridSizeSelector.GridSize; i++)
        {
            text.text = "Points Added: " + (startVal + i).ToString();
            yield return new WaitForSeconds(3.0f / (endVal - startVal));
        }
        text.text = "Points Added: " + endVal.ToString();
    }
}
