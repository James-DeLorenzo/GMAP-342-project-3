using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField]
    private bool Player2 = false;
    private Text score;

    // Start is called before the first frame update
    void Start()
    {
        score = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        score.text = ScoreKeeper.GetScore(Player2).ToString();
    }
}
