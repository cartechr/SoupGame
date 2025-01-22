using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    private InputAction movementAction;
    private InputAction interactAction;
    private PlayerMovement playerMovement;
    private PlayerInteraction playerInteraction;

    // Start is called before the first frame update
    void Start()
    {
        // assign references
        playerMovement = GetComponent<PlayerMovement>();
        playerInteraction = GetComponent<PlayerInteraction>();

        // set up actions
        movementAction = InputSystem.actions.FindAction("Movement");
        interactAction = InputSystem.actions.FindAction("Interact");
    }

    // Update is called once per frame
    void Update()
    {
        playerMovement.ReceiveMovementInput(movementAction.ReadValue<Vector2>());

        if (interactAction.WasPressedThisFrame())
            playerInteraction.ReceiveInteractInput();
    }
}
