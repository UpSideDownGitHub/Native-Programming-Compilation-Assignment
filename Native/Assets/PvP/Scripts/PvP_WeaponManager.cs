using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PvP_WeaponManager : MonoBehaviour
{
    [Header("Current Selected Weapon")]
    public int weaponCount = 3;
    public int currentWeapon;
    public GameObject[] weapons;

    //INPUT
    private bool _leftTrigger;
    private bool _rightTrigger;
    private bool _shootPressed;
    private bool _shootHeld;


    // UI
    public int playerID;
    public PvP_UIManager uiManager;


    public void LeftTrigger(InputAction.CallbackContext ctx) => _leftTrigger = ctx.action.WasPressedThisFrame();
    public void RightTrigger(InputAction.CallbackContext ctx) => _rightTrigger = ctx.action.WasPressedThisFrame();
    public void ShootPressed(InputAction.CallbackContext ctx) => _shootPressed = ctx.action.WasPressedThisFrame();
    public void ShootHeld(InputAction.CallbackContext ctx) => _shootHeld = ctx.action.IsPressed();

    public void Start()
    {
        uiManager = GameObject.FindGameObjectWithTag("PvP_UIManager").GetComponent<PvP_UIManager>();
        if (playerID == 0)
        {
            uiManager.updateP1WeaponsUI();
            uiManager.updateP1AmmoUI();
        }
        else
        {
            uiManager.updateP2WeaponsUI();
            uiManager.updateP2AmmoUI();
        }
    }

    public void Update()
    {
        if (_leftTrigger)
        {
            _leftTrigger = false;
            leftTrigger();
        }
        else if (_rightTrigger)
        {
            _rightTrigger = false;
            rightTrigger();
        }
        
        if (_shootPressed)
        {
            _shootPressed = false;
            ShootPressed();

        }
        else if (_shootHeld)
        {
            ShootHeld();
        }
    }

    public void leftTrigger()
    {
        if (currentWeapon > 0)
        {
            weapons[currentWeapon].SetActive(false);
            currentWeapon--;
            weapons[currentWeapon].SetActive(true);
            if (playerID == 0)
                uiManager.updateP1WeaponsUI();
            else
                uiManager.updateP2WeaponsUI();
        }
    }

    public void rightTrigger()
    {
        if (currentWeapon < weaponCount-1)
        {
            weapons[currentWeapon].SetActive(false);
            currentWeapon++;
            weapons[currentWeapon].SetActive(true);
            if (playerID == 0)
                uiManager.updateP1WeaponsUI();
            else
                uiManager.updateP2WeaponsUI();
        }
    }

    public void ShootHeld()
    {
        weapons[currentWeapon].GetComponent<PvP_Shooting>().ShootHeld();
    }
    public void ShootPressed()
    {
        weapons[currentWeapon].GetComponent<PvP_Shooting>().ShootPressed();
    }
}
