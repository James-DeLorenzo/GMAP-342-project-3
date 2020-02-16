using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ForceDetection : MonoBehaviour
{
    [SerializeField]
    private KeyCode Forcebutton = KeyCode.F;
    private Rigidbody2D rb;

    private float TotalForce = 0;
    private static float ForcePerClick = 20f;

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
        }
    }

    public void AddForce()
    {
        rb.AddForce(new Vector2(TotalForce * (Player2 ? -1 : 1),0));
    }
}
