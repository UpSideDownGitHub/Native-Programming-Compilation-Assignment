using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using static UnityEditor.Progress;

public class PowerupMenu : MonoBehaviour
{
    [Header("Referencing Scripts")]
    public WeaponPickup weaponPickup;
    public Health playerHealth;
    public GameObject mainUI;

    [Header("Menu Navigation")]
    public int curSelected = 0;
    public GameObject[] buttons;
    [Header("Input")]
    public PlayerInput playerInput;
    public InputActionReference Up;
    public InputActionReference Down;
    public void OnEnable()
    {
        // need to change the active map to the menus map and then also make the gamplay stop
        playerInput.SwitchCurrentActionMap("Menus_Map"); // default = Player_Map
        Time.timeScale = 0f;
        Gamepad.current.ResetHaptics();
    }

    public void Update()
    {
        if (Up.action.WasPressedThisFrame() && curSelected > 0)
            curSelected--;
        else if (Down.action.WasPressedThisFrame() && curSelected < 6)
            curSelected++;
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(buttons[curSelected]);
    }

    public void selectPowerUp(int powerupID)
    {
        if (powerupID >= 0 && powerupID <= 4)
        {
            weaponPickup.giveWeapon(powerupID <= 2 ? powerupID : powerupID + 1);
        }
        else if (powerupID == 5)
        {
            playerHealth.maxHealth = 2;
            playerHealth.currentHealth = 2;
        }

        gameObject.SetActive(false);
        mainUI.GetComponent<Canvas>().enabled = true;
        playerInput.SwitchCurrentActionMap("Player_Map"); // default = Player_Map
        Time.timeScale = 1f;
    }
}
