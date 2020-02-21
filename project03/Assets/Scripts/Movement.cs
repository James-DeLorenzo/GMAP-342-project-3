using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    [SerializeField]
    private KeyCode Forward = KeyCode.W;
    [SerializeField]
    private KeyCode RotateLeft = KeyCode.A;
    [SerializeField]
    private KeyCode RotateRight = KeyCode.D;
    private Rigidbody2D rb;

    private static float RotationAmount = 5f;
    private static float Speed = 5f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = Vector2.zero;
        float rotateAmount = 0;
        if (Input.GetKey(Forward))
        {
            direction.y += Speed;
        }
        if (Input.GetKey(RotateLeft)) {
            rotateAmount -= RotationAmount;
        }
        if (Input.GetKey(RotateRight))
        {
            rotateAmount += RotationAmount;
        }
        rb.AddRelativeForce(direction);
        transform.Rotate(-Vector3.forward, rotateAmount);
    }
}
