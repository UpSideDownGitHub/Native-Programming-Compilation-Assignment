using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PvP_PlayerID : MonoBehaviour
{
    public int playerID;

    /*
     * player 1 = blue (objects & bullets)
     * player 2 = red  (objects & bullets)
     * set the ID on the bullet to be the current player ID
    */
    public PvP_PlayerManager manager;
    public PvP_Shooting shooting;
    public PvP_WeaponManager weaponManager;
    public PvP_Health health;

    public void Start()
    {
        manager = GameObject.FindGameObjectWithTag("MANAGER").GetComponent<PvP_PlayerManager>();
        if (playerID == 1) // Player 1 (blue)
        {
            shooting = manager.P1.GetComponent<PvP_Shooting>();
            weaponManager = manager.P1.GetComponent<PvP_WeaponManager>();
            health = manager.P1.GetComponent<PvP_Health>();
            // bullet colour
            foreach(var item in weaponManager.weapons)
            {
                item.GetComponent<Shooting>().bullet.GetComponent<MeshRenderer>().material.color = Color.blue;
            }
            // bullet ID
            shooting.bulletID = 0;
            // weapon manager ID
            weaponManager.playerID = 0;
            // Health ID
            health.playerID = 0;
            // object color
            manager.P1.GetComponent<MeshRenderer>().material.color = Color.blue;
        }
        else if (playerID == 2) // Player 2 (red)
        {
            shooting = manager.P1.GetComponent<PvP_Shooting>();
            weaponManager = manager.P1.GetComponent<PvP_WeaponManager>();
            health = manager.P1.GetComponent<PvP_Health>();
            // bullet colour
            foreach (var item in weaponManager.weapons)
            {
                item.GetComponent<Shooting>().bullet.GetComponent<MeshRenderer>().material.color = Color.red;
            }
            // bullet ID
            shooting.bulletID = 1;
            // weapon manager ID
            weaponManager.playerID = 1;
            // Health ID
            health.playerID = 1;
            // object color
            manager.P1.GetComponent<MeshRenderer>().material.color = Color.red;
        }
    }
}
