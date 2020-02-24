using UnityEngine;
using System;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    [SerializeField]
    private float initialTimer = 5f;

    [SerializeField]
    //taken out due to addition of rounds screen
    //private KeyCode RestartButton = KeyCode.R;
    private GameObject Player1;
    private GameObject Player2;

    public bool canAddForce { get; private set; } = true;
    // use this for the timer UI
    public float Timer { get; private set; }

    public bool ForceApplied { get; private set; } = false;

    public GameObject P1WinScreen;
    public GameObject P2WinScreen;
    public GameObject RoundScreen;

    private void Awake()
    {
        print("P1: " + ScoreKeeper.GetScore(false) + "; P2: " + ScoreKeeper.GetScore(true));
    }

    private void Start()
    {
        HideP1WinScreen();
        HideP2WinScreen();
        HideRoundScreen();

        Player1 = GameObject.Find("Player1");
        Player2 = GameObject.Find("Player2");
        Timer = initialTimer;
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
            //if (!ForceApplied)
            if (ForceApplied == false)
            {
                ForceApplied = true;
                Player1.GetComponent<ForceDetection>().AddForce();
                Player2.GetComponent<ForceDetection>().AddForce();
            }
        }

        //taken out due to addition of rounds screen
        //if (Input.GetKeyDown(RestartButton))
        //{
        //    SceneManager.LoadScene(SceneManager.GetSceneAt(0).name);
        //}
    }

    public void HideP1WinScreen()
    {
        P1WinScreen.SetActive(false);
    }

    public void HideP2WinScreen()
    {
        P2WinScreen.SetActive(false);
    }

    public void HideRoundScreen()
    {
        RoundScreen.SetActive(false);
    }

    public void ShowP1WinScreen()
    {
        P1WinScreen.SetActive(true);
    }

    public void ShowP2WinScreen()
    {
        P2WinScreen.SetActive(true);
    }

    public void ShowRoundScreen()
    {
        RoundScreen.SetActive(true);
    }

}
