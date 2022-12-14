using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PvP_StatsCollector : MonoBehaviour
{
    public static PvP_StatsCollector Instance;

    // create a singleton
    public void OnEnable()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
            Destroy(gameObject);
    }


    public int P1Kills;
    public int P2Kills;
    public int P1Shots;
    public int P2Shots;
    public int P1Hits;
    public int P2Hits;
}
