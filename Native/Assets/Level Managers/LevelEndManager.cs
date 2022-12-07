using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEndManager : MonoBehaviour
{

    /*
     * THIS IS JUST TEMP CODE FOR THE END SO I CAN TEST IT TODAY
    */


    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadSceneAsync(0);
        }
    }
}
