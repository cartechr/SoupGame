using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    private InputAction movementAction;
    private Vector2 input;
    private Rigidbody2D rb;
    [SerializeField]
    private float moveSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        movementAction = InputSystem.actions.FindAction("Movement");
    }

    // Update is called once per frame
    void Update()
    {
        input = movementAction.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(input.x * moveSpeed, input.y * moveSpeed);
    }
}
