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

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("P_DAMAGE"))
        {
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
            // kill the enemy
            // TEMP FOR TESTING
            Debug.Log("THE PLAYER HAS BEEN KILLED");
            currentHealth = maxHealth;
        }
    }
}
