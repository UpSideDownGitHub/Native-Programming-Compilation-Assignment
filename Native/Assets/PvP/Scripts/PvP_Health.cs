using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PvP_Health : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;

    public GameObject spawnPoint;
    private GameManager gameManager;
    public PvP_UIManager uiManager;

    public int playerID;
    public int deaths;

    private int _gunCount = 3;
    private int _outOfAmmoCount = 0;

    public void Start()
    {
        deaths = 0;
        _outOfAmmoCount = 0;
        currentHealth = maxHealth;
        spawnPoint = GameObject.FindGameObjectWithTag("SpawnPoint");
        uiManager = GameObject.FindGameObjectWithTag("PvP_UIManager").GetComponent<PvP_UIManager>();
    }

    public void lostAllAmmo()
    {
        _outOfAmmoCount++;
        if (_outOfAmmoCount == _gunCount)
        {
            // kill the player
            changeHealth(-1000);
        }
    }

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("P_DAMAGE"))
        {
            if (collision.gameObject.GetComponent<INFO>().meleeID == playerID)
                return;

            if (playerID == 0)
                PvP_StatsCollector.Instance.P2Hits++;
            else
                PvP_StatsCollector.Instance.P1Hits++;

            changeHealth(-collision.gameObject.GetComponent<INFO>().damage);
            uiManager.updateHealthUI();
            Destroy(collision.gameObject);
        }
    }

    public void changeHealth(float ammount)
    {
        if (currentHealth + ammount > 0)
            currentHealth += ammount;
        else
        {
            // respawn the player at the spawn position and reset the health of the player
            transform.position = spawnPoint.transform.position;
            deaths++;
            currentHealth = maxHealth;

            _outOfAmmoCount = 0;

            // need to reset the ammo count
            foreach (var weapon in gameObject.GetComponent<PvP_WeaponManager>().weapons)
            {
                weapon.GetComponent<PvP_Shooting>().resetAmmo();
            }

            uiManager.updateKillsUI();

            if (playerID == 0)
                PvP_StatsCollector.Instance.P2Kills++;
            else
                PvP_StatsCollector.Instance.P1Kills++;
        }
    }
}
