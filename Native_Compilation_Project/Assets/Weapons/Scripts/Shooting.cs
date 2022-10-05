using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [Header("Input")]
    public PlayerInput playerInput;

    [Header("Melee")]
    public bool melee;
    public float hitSpeed;
    public float hitCoolDown;
    private bool once = true;


    [Header("Shooting")]
    public GameObject firePoint;
    public GameObject bullet;
    public int maxAmmo;
    public int curAmmo;
    public float bulletSpeed;

    public bool manual;
    public bool shotGun;
    private float shotTime;
    [Header("Manual")]
    public float maxShootRate;

    [Header("Semi-Automatic")]
    public float shootRate;

    [Header("ShotGun")]
    public float maxShootRate2;
    public int bulletAmmout;
    public float deviation;

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
            if (melee)
            {
                if (Time.time > shotTime + hitSpeed && once)
                {
                    once = false;
                    this.GetComponent<BoxCollider>().enabled = false;
                    Debug.Log("disabled");
                }
                if (playerInput.Player_Map.Shoot.WasPressedThisFrame() && Time.time > shotTime + hitCoolDown)
                {
                    Debug.Log("ENABLED");
                    once = true;
                    this.GetComponent<BoxCollider>().enabled = true;
                    shotTime = Time.time;
                }
            }
            else
            {
                if (manual)
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
                else if (!shotGun)
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
                else
                {
                    if (playerInput.Player_Map.Shoot.IsPressed() && Time.time > shotTime + maxShootRate2)
                    {
                        if (curAmmo != 0)
                        {
                            curAmmo--;
                            shotTime = Time.time;
                            for (int i = 0; i < bulletAmmout; i++)
                            {
                                Quaternion _rot = new Quaternion(firePoint.transform.rotation.x, firePoint.transform.rotation.y + Random.Range(-deviation, deviation), firePoint.transform.rotation.z, firePoint.transform.rotation.w + Random.Range(-deviation, deviation));
                                GameObject _temp = Instantiate(bullet, firePoint.transform.position, _rot);
                                _temp.GetComponent<Rigidbody>().AddForce(_temp.transform.forward * bulletSpeed);
                            }
                        }
                    }
                }
            }
        }
    }
}
