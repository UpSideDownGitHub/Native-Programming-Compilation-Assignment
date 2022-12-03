using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PvP_UIManager : MonoBehaviour
{
    public PvP_PlayerManager manager;

    public TMP_Text P1Kills;
    public TMP_Text P1Weapon;
    public TMP_Text P1Ammo;
    public TMP_Text P1TotalAmmo;

    public TMP_Text P2Kills;
    public TMP_Text P2Weapon;
    public TMP_Text P2Ammo;
    public TMP_Text P2TotalAmmo;

    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("MANAGER").GetComponent<PvP_PlayerManager>();
    }
    
    public void updateKillsUI()
    {
        P1Kills.text = "Kills: " + manager.P2.GetComponent<PvP_Health>().deaths.ToString();
        P2Kills.text = "Kills: " + manager.P1.GetComponent<PvP_Health>().deaths.ToString();
    }
    
    public void updateP1WeaponsUI()
    {
        PvP_WeaponManager weaponManager = manager.P1.GetComponent<PvP_WeaponManager>();
        if (weaponManager.currentWeapon == 0)
            P1Weapon.text = "Pistol";
        else if (weaponManager.currentWeapon == 1)
            P1Weapon.text = "Assult Rifle";
        else if (weaponManager.currentWeapon == 2)
            P1Weapon.text = "Shotgun";
        updateP1AmmoUI();
    }
    public void updateP1AmmoUI()
    {
        PvP_WeaponManager weaponManager = manager.P1.GetComponent<PvP_WeaponManager>();
        P1Ammo.text = weaponManager.weapons[weaponManager.currentWeapon].GetComponent<PvP_Shooting>().curAmmo.ToString() + "/" + weaponManager.weapons[weaponManager.currentWeapon].GetComponent<PvP_Shooting>().maxAmmo.ToString();
        P1TotalAmmo.text = weaponManager.weapons[weaponManager.currentWeapon].GetComponent<PvP_Shooting>().curHeldAmmo.ToString();
    }


    public void updateP2WeaponsUI()
    {
        PvP_WeaponManager weaponManager = manager.P2.GetComponent<PvP_WeaponManager>();
        if (weaponManager.currentWeapon == 0)
            P1Weapon.text = "Pistol";
        else if (weaponManager.currentWeapon == 1)
            P1Weapon.text = "Assult Rifle";
        else if (weaponManager.currentWeapon == 2)
            P1Weapon.text = "Shotgun";
        updateP2AmmoUI();
    }
    public void updateP2AmmoUI()
    {
        PvP_WeaponManager weaponManager = manager.P2.GetComponent<PvP_WeaponManager>();
        P2Ammo.text = weaponManager.weapons[weaponManager.currentWeapon].GetComponent<PvP_Shooting>().curAmmo.ToString() + "/" + weaponManager.weapons[weaponManager.currentWeapon].GetComponent<PvP_Shooting>().maxAmmo.ToString();
        P2TotalAmmo.text = weaponManager.weapons[weaponManager.currentWeapon].GetComponent<PvP_Shooting>().curHeldAmmo.ToString();
    }
}
