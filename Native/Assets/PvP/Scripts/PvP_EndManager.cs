using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PvP_EndManager : MonoBehaviour
{
    [Header("Input")]
    public PlayerInput playerInput;
    public InputActionReference Left;
    public InputActionReference Right;
    public InputActionReference A;

    [Header("Menu Navigation")]
    public int curSelected = 0;
    public GameObject[] buttons;

    [Header("Text Objects")]
    public TMP_Text[] P1Stats;
    public TMP_Text[] P2Stats;
    /*
     * 0 - kills
     * 1 - deaths
     * 2 - KD
     * 3 - shots
     * 4 - accuracy
    */
    public GameObject P1Won;
    public GameObject P2Won;

    public void OnEnable()
    {
        var playerInput = GameObject.FindGameObjectWithTag("MANAGER").GetComponent<PvP_PlayerManager>();
        playerInput.P1.GetComponentInChildren<PlayerInput>().SwitchCurrentActionMap("Menus_Map");
        playerInput.P2.GetComponentInChildren<PlayerInput>().SwitchCurrentActionMap("Menus_Map");

        // P1
        P1Stats[0].text = PvP_StatsCollector.Instance.P1Kills.ToString();
        P1Stats[1].text = PvP_StatsCollector.Instance.P2Kills.ToString();
        if (PvP_StatsCollector.Instance.P2Kills == 0)
            P1Stats[2].text = PvP_StatsCollector.Instance.P1Kills.ToString();
        else
            P1Stats[2].text = ((float)((float)PvP_StatsCollector.Instance.P1Kills / (float)PvP_StatsCollector.Instance.P2Kills)).ToString();

        P1Stats[3].text = PvP_StatsCollector.Instance.P1Shots.ToString();

        if (PvP_StatsCollector.Instance.P1Shots == 0 || PvP_StatsCollector.Instance.P1Hits == 0)
            P1Stats[4].text = "0";
        else
            P1Stats[4].text = ((float)((float)PvP_StatsCollector.Instance.P1Hits / (float)PvP_StatsCollector.Instance.P1Shots) * 100f).ToString();

        // P2
        P2Stats[0].text = PvP_StatsCollector.Instance.P2Kills.ToString();
        P2Stats[1].text = PvP_StatsCollector.Instance.P1Kills.ToString();
        if (PvP_StatsCollector.Instance.P1Kills == 0)
            P2Stats[2].text = PvP_StatsCollector.Instance.P2Kills.ToString();
        else
            P2Stats[2].text = ((float)((float)PvP_StatsCollector.Instance.P2Kills / (float)PvP_StatsCollector.Instance.P1Kills)).ToString();
        P2Stats[3].text = PvP_StatsCollector.Instance.P2Shots.ToString();
        if (PvP_StatsCollector.Instance.P2Shots == 0 || PvP_StatsCollector.Instance.P2Hits == 0)
            P2Stats[4].text = "0";
        else
            P2Stats[4].text = ((float)((float)PvP_StatsCollector.Instance.P2Hits / (float)PvP_StatsCollector.Instance.P2Shots) * 100f).ToString();

        // Winner
        if (PvP_StatsCollector.Instance.P1Kills > PvP_StatsCollector.Instance.P2Kills)
        {
            // Player 1 wins
            P1Won.SetActive(true);
            P2Won.SetActive(false);
        }
        else
        {
            // Player 2 wins
            P1Won.SetActive(false);
            P2Won.SetActive(true);
        }
    }

    public void Update()
    {
        if (Left.action.WasPressedThisFrame() && curSelected > 0)
        { 
            curSelected--;
        }
        else if (Right.action.WasPressedThisFrame() && curSelected < 1)
        { 
            curSelected++;
        }
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(buttons[curSelected]);
    }

    public void restart()
    {
        SceneManager.LoadSceneAsync(16);
    }
    public void mainMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
