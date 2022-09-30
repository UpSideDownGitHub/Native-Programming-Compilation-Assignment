using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Player;
    public Vector3 Offset;

    public void Update()
    {
        if (Player != null)
        {
            transform.position = Player.position + Offset;
        }
    }
}
