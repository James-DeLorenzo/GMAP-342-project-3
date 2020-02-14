using UnityEngine;
using System;


public class GameManager : MonoBehaviour
{
    private float player1Score = 0;
    private float player2Score = 0;
    private GameObject Player1;
    private GameObject Player2;


    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("GameManager");

        if(objs.Length > 1)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        Player1 = GameObject.Find("Player1");
        Player2 = GameObject.Find("Player2");
    }

    public void UpdateScore(int player)
    {
        if (player < 1 || player > 2)
        {
            throw new IndexOutOfRangeException("player must be 1 or 2");
        }

        if(player == 1)
        {
            player1Score++;
        }
        else
        {
            player2Score++;
        }
    }

    public void Countdown()
    {
        //TODO: implement countdown
        throw new NotImplementedException();
    }
}
