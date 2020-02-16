using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class WinDetection : MonoBehaviour
{
    private Rigidbody2D rb;
    private static bool hit = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!hit)
        {
            if (gameObject.GetComponent<ForceDetection>().GetTotalForce() > collision.gameObject.GetComponent<ForceDetection>().GetTotalForce())
            {
                print(int.Parse(gameObject.name.Replace("Player", "")) + " WON");
                ScoreKeeper.UpdateScore(int.Parse(gameObject.name.Replace("Player", "")));
            }
            else
            {
                print(int.Parse(gameObject.name.Replace("Player", "")) + " lost");
                //TODO: instantiate smaller pieces, possible use particle system prefab
                Destroy(gameObject);
            }
        }
    }
}
