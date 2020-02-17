using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ForceDetection : MonoBehaviour
{
    [SerializeField]
    private KeyCode Forcebutton = KeyCode.F;
    private Rigidbody2D rb;
    [SerializeField]
    private float TotalForce = 0;
    private static float ForcePerClick = 5f;

    [SerializeField]
    private bool Player2 = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(Forcebutton))
        {
            TotalForce += ForcePerClick;

            if(Player2 == true)
            {
                GameObject.Find("ForcebarP2").GetComponent<ForceBar>().AddForce(1);
            }
            else
            {
                GameObject.Find("ForcebarP1").GetComponent<ForceBar>().AddForce(1);
            }

        }
    }

    public void AddForce()
    {
        rb.AddForce(new Vector2(TotalForce * (Player2 ? -1 : 1),0), ForceMode2D.Impulse);
    }

    public float GetTotalForce()
    {
        return TotalForce;
    }
}
