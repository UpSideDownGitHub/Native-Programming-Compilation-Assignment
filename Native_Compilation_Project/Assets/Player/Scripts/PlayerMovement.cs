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
    [Header("Input")]
    public PlayerInput playerInput;
    public InputActionReference Mouse;
    public InputActionReference Movement;
    public InputActionReference Dodge;

    [Header("Rotation")]
    public float strength = 5;
    public Vector3 prevRotation;
    #endregion

    private void Awake()
    {
        _rb = this.GetComponent<Rigidbody>();

        string savedInput = PlayerPrefs.GetString("Controls", string.Empty);
        playerInput.actions.LoadBindingOverridesFromJson(savedInput);
    }

    // rotates the mouse positions
    public void Update()
    {
        Vector2 _mousePos = Mouse.action.ReadValue<Vector2>();
        Vector3 _temp = new Vector3(_mousePos.x, 0, _mousePos.y);
        if (_temp != Vector3.zero)
        {
            prevRotation = _temp;
            transform.rotation = Quaternion.LookRotation(_temp);
        }
        else
            transform.rotation = Quaternion.LookRotation(prevRotation);
    }
    
    public void LateUpdate()
    {
        Vector2 _vec2 = Movement.action.ReadValue<Vector2>();
        if (_vec2 != Vector2.zero)
        {
            Vector3 _moveInput = new Vector3(_vec2.x, 0, _vec2.y);
            Vector3 zero = Vector3.zero;
            if (Dodge.action.WasPressedThisFrame())
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
