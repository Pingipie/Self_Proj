using _InputTest.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour, MoveInput, IRotationInput
{
    private InputMaster controls;
    private Vector2 move;
    public Command movementInput;

    public Vector3 MoveDirection { get; private set; }
    public Vector3 RotationDirection { get; set; }

    private void Awake()
    {
        controls = new InputMaster();
    }

    private void OnEnable()
    {
        if (movementInput)
            controls.Player.Movement.performed += OnMoveInput;

        controls.Player.Interact.performed += OnInteractButton;
    }

    private void OnMoveInput(InputAction.CallbackContext context)
    {
        var value = context.ReadValue<Vector2>();
        MoveDirection = new Vector3(value.x, (float)0.6, value.y);

        if (movementInput != null)
            movementInput.Execute();
    }

    private void OnInteractButton(InputAction.CallbackContext context)
    {
        var value = context.ReadValue<float>();
    }


    private void OnDisable()
    {
        controls.Player.Interact.performed -= OnInteractButton;
    }
}
