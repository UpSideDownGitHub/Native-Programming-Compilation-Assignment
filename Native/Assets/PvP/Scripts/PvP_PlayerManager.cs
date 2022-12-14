using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PvP_PlayerManager : MonoBehaviour
{
    public int playerCount;
    public GameObject P1;
    public GameObject P2;
    public Gamepad P1Gamepad;
    public Gamepad P2Gamepad;

    public void PlayerJoined(PlayerInputManager ctx)
    {
        playerCount = ctx.playerCount;

        if (playerCount == 1) // first player
        {
            Object[] objects = Resources.FindObjectsOfTypeAll(typeof(PvP_Movement));
            objects[0].GetComponent<PvP_PlayerID>().playerID = 1;
            P1 = objects[0].GameObject();
            P1Gamepad = Gamepad.current;
        }
        else
        {
            var objects = Resources.FindObjectsOfTypeAll(typeof(PvP_Movement));
            objects[0].GetComponent<PvP_PlayerID>().playerID = 2;
            P2 = objects[0].GameObject();
            P2Gamepad = Gamepad.current;
        }

    }

    public void PlayerLeft()
    {
        Debug.Log("Player Left");
    }
}
