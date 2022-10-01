using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [Header("Input")]
    public PlayerInput playerInput;

    [Header("Shooting")]
    public GameObject firePoint;
    public GameObject bullet;
    public int maxAmmo;
    public int curAmmo;
    public float bulletSpeed;

    public bool Manual;
    private float shotTime;
    [Header("Manual")]
    public float maxShootRate;

    [Header("Semi-Automatic")]
    public float shootRate;

    // Start is called before the first frame update
    public void Start()
    {
        playerInput = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().playerInput;
        shotTime = 0;
    }

    // Update is called once per frame
    public void Update()
    {
        if (!this.GetComponent<ID>().pickup)
        {
            if (Manual)
            {
                if (playerInput.Player_Map.Shoot.WasPressedThisFrame() && Time.time > shotTime + maxShootRate)
                {
                    if (curAmmo != 0)
                    {
                        curAmmo--;
                        shotTime = Time.time;
                        GameObject _temp = Instantiate(bullet, firePoint.transform.position, firePoint.transform.rotation);
                        _temp.GetComponent<Rigidbody>().AddForce(_temp.transform.forward * bulletSpeed);
                    }
                }
            }
            else
            {
                if (playerInput.Player_Map.Shoot.IsPressed() && Time.time > shotTime + shootRate)
                {
                    if (curAmmo != 0)
                    {
                        curAmmo--;
                        shotTime = Time.time;
                        GameObject _temp = Instantiate(bullet, firePoint.transform.position, firePoint.transform.rotation);
                        _temp.GetComponent<Rigidbody>().AddForce(_temp.transform.forward * bulletSpeed);
                    }
                }
            }
        }
    }
}
