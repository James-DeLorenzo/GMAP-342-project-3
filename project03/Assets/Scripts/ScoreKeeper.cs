using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    private static int player1Score = 0;
    private static int player2Score = 0;

    public static void UpdateScore(int player)
    {
        if (player < 1 || player > 2)
        {
            throw new IndexOutOfRangeException("player must be 1 or 2");
        }

        if (player == 1)
        {
            player1Score++;
        }
        else
        {
            player2Score++;
        }
    }

    public static int GetScore(bool player2)
    {
        return player2 ? player2Score : player1Score;
    }
}
