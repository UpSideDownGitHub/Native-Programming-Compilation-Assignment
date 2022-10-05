using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth;
    public float curHealth;
    public void OnEnable()
    {
        curHealth = maxHealth;
    }

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("E_DAMAGE"))
        {
            takeDamage(collision.gameObject.GetComponent<INFO>().damage);
            Destroy(collision.gameObject);
        }
    }

    public void takeDamage(float damage)
    {
        if (curHealth - damage > 0)
            curHealth -= damage;
        else
        {
            // kill the enemy
            // TEMP FOR TESTING
            Debug.Log("THE ENEMY HAS BEEN KILLED");
            curHealth = maxHealth;
        }
        
    }
}
