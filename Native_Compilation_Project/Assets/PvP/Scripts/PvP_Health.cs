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

    public int playerID;
    public int deaths;

    public void Start()
    {
        deaths = 0;
        currentHealth = maxHealth;
        spawnPoint = GameObject.FindGameObjectWithTag("SpawnPoint");
    }

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("P_DAMAGE"))
        {
            print(collision.gameObject.GetComponent<INFO>().meleeID);
            print(playerID);
            if (collision.gameObject.GetComponent<INFO>().meleeID == playerID)
                return;
            changeHealth(-collision.gameObject.GetComponent<INFO>().damage);
            Destroy(collision.gameObject);
        }
    }

    public void changeHealth(float ammount)
    {
        if (currentHealth + ammount > 0)
            currentHealth += ammount;
        else
        {
            // respawn the player at the spawn position
            transform.position = spawnPoint.transform.position;
            deaths++;
            GameObject.FindGameObjectWithTag("PvP_UIManager").GetComponent<PvP_UIManager>().updateKillsUI();
        }
    }
}
