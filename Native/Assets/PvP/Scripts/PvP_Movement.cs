using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;
using UnityEngine.Rendering;

public class PvP_Movement : MonoBehaviour
{
    [Header("Movement")]
    public float movementSpeed = 10f;
    public float smoothValue = 0.2f;
    public float dodgeMultiplier = 3;

    // INPUT
    private Vector2 _mousePos;
    private Vector2 _vec2;
    private bool _dodge;

    private Rigidbody _rb;

    [Header("Rotation")]
    public float strength = 5;
    public Vector3 prevRotation;

    [Header("Sound")]
    public AudioSource audioSource;
    public AudioClip walkingSound;

    [Header("Menu Button")]
    public int playerID;
    private bool _APressed;

    [Header("Pause Menu")]
    public bool _pausePressed;
    public static bool paused;
    public static int pauseID;

    [Header("Controller Lost")]
    public static bool lostP1;
    public static bool lostP2;



    private void Awake()
    {
        _rb = this.GetComponent<Rigidbody>();
    }

    public void Movement(InputAction.CallbackContext ctx) => _vec2 = ctx.ReadValue<Vector2>();
    public void Mouse(InputAction.CallbackContext ctx) => _mousePos = ctx.ReadValue<Vector2>();
    public void Dodge(InputAction.CallbackContext ctx) => _dodge = ctx.action.WasPressedThisFrame();

    // for the stating menu
    public void AButton(InputAction.CallbackContext ctx)
    {
        _APressed = ctx.action.WasPressedThisFrame();
    }

    public void Pause(InputAction.CallbackContext ctx)
    {
        _pausePressed = ctx.action.WasPressedThisFrame();
    }

    public void lostController()
    {
        if (playerID == 1)
        {
            lostP1 = true;
        }
        else if (playerID == 2)
        {
            lostP2 = true;
        }
    }

    public void regainedController()
    {
        if (playerID == 1)
        {
            lostP1 = false;
        }
        else if (playerID == 2)
        {
            lostP2 = false;
        }
    }


    // rotates the mouse positions
    public void Update()
    {
        if (lostP1 || lostP2)
            return;

        if (_pausePressed)
        {
            _pausePressed = false;
            if (!paused)
            {
                paused = true;
                pauseID = playerID;
            }
        }

        // for the start menu
        if (_APressed)
        {
            _APressed = false;
            Debug.Log(playerID);
            if (playerID == 1) // player 1
            {
                GameObject.FindGameObjectWithTag("PvP_UIManager").GetComponent<PvP_StartManager>().p1Ready();
            }
            else if (playerID == 2) // player 2
            {
                GameObject.FindGameObjectWithTag("PvP_UIManager").GetComponent<PvP_StartManager>().p2Ready();
            }
        }

        if (Time.timeScale != 0)
        {
            Vector3 _temp = new Vector3(_mousePos.x, 0, _mousePos.y);
            if (_temp != Vector3.zero)
            {
                prevRotation = _temp;
                transform.rotation = Quaternion.LookRotation(_temp);
            }
            else
            {
                if (prevRotation != Vector3.zero)
                    transform.rotation = Quaternion.LookRotation(prevRotation);
            }
        }
    }

    public void LateUpdate()
    {
        if (_vec2 != Vector2.zero)
        {
            if (!audioSource.isPlaying)
                audioSource.Play();
            Vector3 _moveInput = new Vector3(_vec2.x, 0, _vec2.y);
            Vector3 zero = Vector3.zero;
            if (_dodge)
            {
                _rb.velocity = _moveInput * movementSpeed * dodgeMultiplier;
                return;
            }
            _rb.velocity = Vector3.SmoothDamp(_rb.velocity, _moveInput * movementSpeed, ref zero, smoothValue);
        }
        else
        {
            audioSource.Stop();
            _rb.velocity = Vector2.zero;
        }
    }
}
