using UnityEngine;
using System;


public class GameManager : MonoBehaviour
{
    [SerializeField]
    private float initialTimer = 10f;
    private static float player1Score = 0;
    private static float player2Score = 0;
    private GameObject Player1;
    private GameObject Player2;

    public bool canAddForce { get; private set; } = true;
    // use this for the timer UI
    public float Timer { get; private set; }

    private bool ForceApplied = false;


    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("GameManager");

        if (objs.Length > 1)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (Timer > 0)
        {
            Timer -= Time.deltaTime;
        }
        else
        {
            Timer = 0;
            if (!ForceApplied)
            {
                ForceApplied = true;
                Player1.GetComponent<ForceDetection>().AddForce();
                Player2.GetComponent<ForceDetection>().AddForce();
            }
        }
    }

    private void Start()
    {
        Player1 = GameObject.Find("Player1");
        Player2 = GameObject.Find("Player2");
        Timer = initialTimer;
    }

    public void UpdateScore(int player)
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

    public void Countdown()
    {
        //TODO: implement countdown
        throw new NotImplementedException();
    }
}
