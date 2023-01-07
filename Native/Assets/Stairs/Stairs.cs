using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stairs : MonoBehaviour
{
    public void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            try { GameObject.FindGameObjectWithTag("MANAGER").GetComponent<GameManager>().stairs(); }
            catch { /* WAS NOT FOUND, ALREADY ENDED THE LEVEL */ }
            
        }
    }
}
