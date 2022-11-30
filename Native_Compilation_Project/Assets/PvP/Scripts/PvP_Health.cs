using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PvP_Health : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;

    public GameObject SpawnPoint;
    private GameManager gameManager;

    public int playerID;

    public void Start()
    {
        currentHealth = maxHealth;
    }

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("P_DAMAGE"))
        {
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
            transform.position = SpawnPoint.transform.position;
        }
    }
}
