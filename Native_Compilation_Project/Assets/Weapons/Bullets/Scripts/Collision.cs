using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    public GameObject particleEffect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player"
            && other.gameObject.tag != "Enemy"
            && other.gameObject.tag != "IGNORE"
            && other.gameObject.tag != "P_DAMAGE"
            && other.gameObject.tag != "E_DAMAGE"
            && other.gameObject.tag != "PICKUP")
        {
            Destroy(gameObject);
            Instantiate(particleEffect, transform.position, transform.rotation);
        }
    }
}
