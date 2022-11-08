using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth;
    public float curHealth;

    [Header("Droping Weapon")]
    public bool fists;
    public GameObject gunToDrop;
    public Enemy enemy;

    public float maxForce;
    public float minForce;
    public float maxTorque;
    public float minTorque;

    [Header("Score")]
    public int score;
    private ScoreManager scoreManager;

    private bool alreadyDropped = false;

    public void OnEnable()
    {
        curHealth = maxHealth;
        enemy = GetComponent<Enemy>();
        scoreManager = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();
    }

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("E_DAMAGE"))
        {
            takeDamage(collision.gameObject.GetComponent<INFO>().damage);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("E_DAMAGE_MELEE"))
        {
            takeDamage(collision.gameObject.GetComponent<INFO>().damage);
        }
    }

    public void takeDamage(float damage)
    {
        if (curHealth - damage > 0)
            curHealth -= damage;
        else
        {
            if (!alreadyDropped)
            {
                alreadyDropped = true;
                if (!fists)
                {
                    GameObject _temp2 = Instantiate(gunToDrop, enemy.firePoint.transform.position, enemy.firePoint.transform.rotation);
                    _temp2.GetComponent<ID>().curAmmo = enemy.curAmmo;
                    _temp2.GetComponent<ID>().pickup = true;
                    _temp2.GetComponent<Rigidbody>().AddForce(transform.forward * Random.Range(minForce, maxForce));
                    _temp2.GetComponent<Rigidbody>().AddTorque(new Vector3(Random.Range(minTorque, maxTorque), Random.Range(minTorque, maxTorque), Random.Range(minTorque, maxTorque)));
                }
                Destroy(gameObject);

                // increase score by the ammount this enemy adds (specific to each enemy)
                scoreManager.changeScore(score);
            }
        }
        
    }
}
