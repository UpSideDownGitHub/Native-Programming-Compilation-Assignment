using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public Collider col;
    public float maxHealth;
    public float currentHealth;
    public int currentScene = 1;

    public void Start()
    {
        currentHealth = maxHealth;
    }

    public void OnTriggerEnter(Collider collision)
    {
        //col.is
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
            SceneManager.LoadSceneAsync(currentScene);
        }
    }
}
