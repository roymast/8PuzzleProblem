using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public static class PlayerData
{
    const char SEPERATOR = ',';
    const string BEST_TIME = "bestTime";
    const string BEST_MOVES = "bestMoves";
    const string POINTS = "points";
    const string IS_MUSIC_ACTIVE = "IsMusicActive";
    const string IS_SFX_ACTIVE = "IsSFXActive";

    public static bool MusicActive
    {
        get { return PlayerPrefs.GetInt(IS_MUSIC_ACTIVE) == 1; }
        set { PlayerPrefs.SetInt(IS_MUSIC_ACTIVE, value ? 1 : 0); }
    }
    public static bool SFXActive
    {
        get { return PlayerPrefs.GetInt(IS_SFX_ACTIVE) == 1; }
        set { PlayerPrefs.SetInt(IS_SFX_ACTIVE, value ? 1 : 0); }
    }
    public static int PlayerPoints
    {
        get { return PlayerPrefs.GetInt(POINTS); }
        set { if (value > 0) PlayerPrefs.SetInt(POINTS, value); }
    }

    public static void TryUpdateBestScore(int time, int moves)
    {
        string bestTimeStr = PlayerPrefs.GetString(BEST_TIME);
        if (int.TryParse(bestTimeStr.Split(SEPERATOR)[0], out int bestTimeVal))
        {
            if (bestTimeVal > time)
                PlayerPrefs.SetString(BEST_TIME, $"{time} {SEPERATOR} {moves}");
        }
        else
            PlayerPrefs.SetString(BEST_TIME, $"{time} {SEPERATOR} {moves}");
    }
    public static void TryUpdateBestMoves(int time, int moves)
    {
        string bestmovesStr = PlayerPrefs.GetString(BEST_MOVES);
        if (int.TryParse(bestmovesStr.Split(SEPERATOR)[0], out int bestMovesVal))
        {
            if (bestMovesVal > moves)
                PlayerPrefs.SetString(BEST_MOVES, $"{time} {SEPERATOR} {moves}");
        }
        else
            PlayerPrefs.SetString(BEST_MOVES, $"{time} {SEPERATOR} {moves}");
    }
    public static void AddPoints(int points)
    {
        PlayerPoints += points;
    }
    public static bool ReducePoints(int points)
    {
        if (PlayerPoints < points)
            return false;

        PlayerPoints -= points;
        return true;
    }
}