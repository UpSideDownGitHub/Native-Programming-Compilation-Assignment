using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class PlayerMovement : MonoBehaviour
{
    #region VARIABLES
    [Header("Movement")]
    public float movementSpeed = 10f;
    public float smoothValue = 0.2f;
    public float dodgeMultiplier = 3;

    private Rigidbody _rb;
    public PlayerInput playerInput;

    [Header("Rotation")]
    public float strength = 5;
    public Vector3 prevRotation;
    #endregion

    private void Awake()
    {
        playerInput = new();
        _rb = this.GetComponent<Rigidbody>();
    }

    public void OnEnable()
    {
        playerInput.Enable();
    }

    public void OnDisable()
    {
        playerInput.Disable();
    }

    // rotates the mouse positions
    public void Update()
    {
        Vector2 _mousePos = playerInput.Player_Map.Mouse.ReadValue<Vector2>();
        Vector3 _temp = new Vector3(_mousePos.x, 0, _mousePos.y);
        if (_temp != Vector3.zero)
        {
            prevRotation = _temp;
            transform.rotation = Quaternion.LookRotation(_temp);
        }
        else
            transform.rotation = Quaternion.LookRotation(prevRotation);
    }
    
    void FixedUpdate()
    {
        
    }
    public void LateUpdate()
    {
        Vector2 _vec2 = playerInput.Player_Map.Movement.ReadValue<Vector2>();
        if (_vec2 != Vector2.zero)
        {
            Vector3 _moveInput = new Vector3(_vec2.x, 0, _vec2.y);
            Vector3 zero = Vector3.zero;
            if (playerInput.Player_Map.Dodge.WasPressedThisFrame())
            {
                _rb.velocity = _moveInput * movementSpeed * dodgeMultiplier;
                return;
            }
            _rb.velocity = Vector3.SmoothDamp(_rb.velocity, _moveInput * movementSpeed, ref zero, smoothValue);
        }
        else
        {
            _rb.velocity = Vector2.zero;
        }
    }
}
