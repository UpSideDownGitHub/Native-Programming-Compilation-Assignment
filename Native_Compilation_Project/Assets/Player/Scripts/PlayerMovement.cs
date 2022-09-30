using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float movementSpeed = 10f;
    public float smoothValue = 0.2f;

    private Rigidbody rb;
    private PlayerInput playerInput;

    [Header("Rotation")]
    public float strength = 5;

    private void Awake()
    {
        playerInput = new PlayerInput();
        rb = this.GetComponent<Rigidbody>();
    }

    public void OnEnable()
    {
        playerInput.Player_Map.Enable();
    }

    public void OnDisable()
    {
        playerInput.Player_Map.Disable();
    }

    public void Update()
    { 
        Vector2 _mousePos = playerInput.Player_Map.Mouse.ReadValue<Vector2>();
        Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);
        Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(_mousePos);
        float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);
        transform.rotation = Quaternion.Euler(new Vector3(0f, -angle - 90, 0f));
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
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
            //rb.velocity = _moveInput * movementSpeed;
            Vector3 zero = Vector3.zero;
            rb.velocity = Vector3.SmoothDamp(rb.velocity, _moveInput * movementSpeed, ref zero, smoothValue);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }
}
