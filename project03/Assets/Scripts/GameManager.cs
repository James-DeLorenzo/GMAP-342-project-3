using UnityEngine;
using System;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    [SerializeField]
    private float initialTimer = 5f;
    [SerializeField]
    private KeyCode RestartButton = KeyCode.R;
    private GameObject Player1;
    private GameObject Player2;

    public bool canAddForce { get; private set; } = true;
    // use this for the timer UI
    public float Timer { get; private set; }

    private bool ForceApplied = false;


    private void Awake()
    {
        print("P1: " + ScoreKeeper.GetScore(false) + "; P2: " + ScoreKeeper.GetScore(true));
    }

    private void Start()
    {
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
            if (!ForceApplied)
            {
                ForceApplied = true;
                Player1.GetComponent<ForceDetection>().AddForce();
                Player2.GetComponent<ForceDetection>().AddForce();
            }
        }

        if (Input.GetKeyDown(RestartButton))
        {
            SceneManager.LoadScene(SceneManager.GetSceneAt(0).name);
        }
    }
}
