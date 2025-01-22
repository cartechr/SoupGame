using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 movementInput;
    private Rigidbody2D rb;
    [SerializeField]
    private float moveSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(movementInput.x * moveSpeed, movementInput.y * moveSpeed);
    }

    public void ReceiveMovementInput(Vector2 input)
    {
        movementInput = input;
    }
}
