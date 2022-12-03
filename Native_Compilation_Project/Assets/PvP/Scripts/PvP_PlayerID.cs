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
    public PvP_WeaponManager weaponManager;
    public PvP_Health health;
    public PvP_StartManager startManager;

    public void Start()
    {
        manager = GameObject.FindGameObjectWithTag("MANAGER").GetComponent<PvP_PlayerManager>();
        startManager = GameObject.FindGameObjectWithTag("PvP_UIManager").GetComponent<PvP_StartManager>();
        if (playerID == 1) // Player 1 (blue)
        {
            weaponManager = manager.P1.GetComponent<PvP_WeaponManager>();
            health = manager.P1.GetComponent<PvP_Health>();
            // bullet colour
            foreach(var item in weaponManager.weapons)
            {
                item.GetComponent<PvP_Shooting>().bullet.GetComponent<MeshRenderer>().sharedMaterial.color = Color.blue;
            }
            // bullet ID
            foreach (var item in weaponManager.weapons)
            {
                item.GetComponent<PvP_Shooting>().bulletID = 0;
            }
            // weapon manager ID
            weaponManager.playerID = 0;
            // Health ID
            health.playerID = 0;
            // object color
            manager.P1.GetComponent<MeshRenderer>().material.color = Color.blue;
            // start manager P1
            startManager.p1JoinedGame();
        }
        else if (playerID == 2) // Player 2 (red)
        {
            weaponManager = manager.P2.GetComponent<PvP_WeaponManager>();
            health = manager.P2.GetComponent<PvP_Health>();
            // bullet colour
            foreach (var item in weaponManager.weapons)
            {
                item.GetComponent<PvP_Shooting>().bullet.GetComponent<MeshRenderer>().sharedMaterial.color = Color.red;
            }
            // bullet ID
            foreach (var item in weaponManager.weapons)
            {
                item.GetComponent<PvP_Shooting>().bulletID = 1;
            }
            // weapon manager ID
            weaponManager.playerID = 1;
            // Health ID
            health.playerID = 1;
            // object color
            manager.P2.GetComponent<MeshRenderer>().material.color = Color.red;
            // start manager P1
            startManager.p2JoinedGame();
        }
    }
}
