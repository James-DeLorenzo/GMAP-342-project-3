using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class WinDetection : MonoBehaviour
{
    private Rigidbody2D rb;
    private GameManager gm;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //throw new KeyNotFoundException();
        if(rb.velocity.magnitude > collision.gameObject.GetComponent<Rigidbody2D>().velocity.magnitude)
        {
            //TODO: find how to tag players to pass to score
            gm.UpdateScore(int.Parse(gameObject.name.Replace("Player","")));
        }
        else
        {
            //TODO: instantiate smaller pieces, possible use particle system prefab
            Destroy(gameObject);
        }
    }
}
