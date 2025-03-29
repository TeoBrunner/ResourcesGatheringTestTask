using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;

    private InputAction pointerDeltaAction;
    private InputAction pointerDownAction;

    public event Action<Vector2> pointerDragged;
    public event Action pointerPressed;
    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();

        pointerDeltaAction = playerInput.actions.FindAction("PointerDelta");
        pointerDownAction = playerInput.actions.FindAction("PointerDown");
    }

    private void OnEnable()
    {
        pointerDeltaAction.performed += OnPointerDelta;
        pointerDownAction.performed += OnPointerDown;
    }

    private void OnDisable()
    {
        pointerDeltaAction.performed -= OnPointerDelta;
        pointerDownAction.performed -= OnPointerDown;
    }
        
    private void OnPointerDelta(InputAction.CallbackContext context)
    {        
        Vector2 value = context.ReadValue<Vector2>();

        pointerDragged?.Invoke(value);
    }

    private void OnPointerDown(InputAction.CallbackContext context)
    {
        pointerPressed?.Invoke();
    }
}
