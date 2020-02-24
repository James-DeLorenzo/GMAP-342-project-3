using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class WinDetection : MonoBehaviour
{
    private Rigidbody2D rb;
    //private static bool hit = false;

    public Transform spawnPoint1;
    public Transform spawnPoint2;
    public Transform spawnPoint3;
    public GameObject piecePrefab1;
    public GameObject piecePrefab2;
    public GameObject piecePrefab3;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (gameObject.GetComponent<HealthBar>().GetCurrentHealth() > 0f && collision.gameObject.GetComponent<HealthBar>().GetCurrentHealth() <= 0f)
            {
                ScoreKeeper.UpdateScore(int.Parse(gameObject.name.Replace("Player", "")));
            }
            else if(gameObject.GetComponent<HealthBar>().GetCurrentHealth() <= 0f && collision.gameObject.GetComponent<HealthBar>().GetCurrentHealth() > 0f)
            {
                Debug.Log(gameObject.GetComponent<HealthBar>().GetCurrentHealth());
                Debug.Log("death");
                GameObject Piece1 = Instantiate(piecePrefab1, spawnPoint1.position, spawnPoint1.rotation);
                GameObject Piece2 = Instantiate(piecePrefab2, spawnPoint2.position, spawnPoint2.rotation);
                GameObject Piece3 = Instantiate(piecePrefab3, spawnPoint3.position, spawnPoint3.rotation);
                Destroy(gameObject);
                FindObjectOfType<GameManager>().ShowRoundScreen();
            }
        }
    }
}
