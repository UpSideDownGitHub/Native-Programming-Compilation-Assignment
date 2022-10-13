using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;

    public void Start()
    {
        currentHealth = maxHealth;
    }

    public void changeHealth(float ammount)
    {
        currentHealth += ammount;
        if (currentHealth <= 0)
        {
            // DESTROY 
            // testing
            Debug.Log("Player Died");
            currentHealth = maxHealth;
        }
    }
}
