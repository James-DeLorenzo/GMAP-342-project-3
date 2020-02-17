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

        if(player1Score >= 5)
        {
            FindObjectOfType<GameManager>().ShowP1WinScreen();
            player1Score = 0;
            player2Score = 0;

        }
        else if (player2Score >= 5)
        {
            FindObjectOfType<GameManager>().ShowP2WinScreen();
            player1Score = 0;
            player2Score = 0;
        }

    }

    public static int GetScore(bool player2)
    {
        return player2 ? player2Score : player1Score;
    }
}
