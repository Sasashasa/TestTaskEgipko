using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
    public static GameInput Instance { get; private set; }
    
    public event EventHandler OnJumpAction;
    
    private PlayerInputActions _playerInputActions;
    
    private void Awake()
    {
        Instance = this;
        
        _playerInputActions = new PlayerInputActions();
        
        _playerInputActions.Player.Enable();
        
        _playerInputActions.Player.Jump.performed += JumpPerformed;
    }

    private void OnDestroy()
    {
        _playerInputActions.Player.Jump.performed -= JumpPerformed;
        
        _playerInputActions.Dispose();
    }

    public Vector2 GetMovementVectorNormalized()
    {
        Vector2 inputVector = _playerInputActions.Player.Move.ReadValue<Vector2>();
        
        inputVector = inputVector.normalized;
        
        return inputVector;
    }
    
    
    private void JumpPerformed(InputAction.CallbackContext obj)
    {
        OnJumpAction?.Invoke(this, EventArgs.Empty);
    }
}