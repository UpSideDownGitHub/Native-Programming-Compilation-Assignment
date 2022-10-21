using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shooting : MonoBehaviour
{
    [Header("Input")]
    public PlayerInput playerInput;
    public InputActionReference Shoot;

    [Header("Sound")]
    public float soundDistance;

    [Header("Bullet")]
    public float damage;

    [Header("Melee")]
    public bool melee;
    public float hitSpeed;
    public float hitCoolDown;
    private bool once = true;
    public Collider col;


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
                    col.enabled = false;
                }
                if (Shoot.action.WasPressedThisFrame() && Time.time > shotTime + hitCoolDown)
                { 
                    once = true;
                    col.enabled = true;
                    shotTime = Time.time;

                    makeSound();
                }
            }
            else
            {
                if (manual)
                {
                    if (Shoot.action.WasPressedThisFrame() && Time.time > shotTime + maxShootRate)
                    {
                        if (curAmmo != 0)
                        {
                            curAmmo--;
                            shotTime = Time.time;
                            GameObject _temp = Instantiate(bullet, firePoint.transform.position, firePoint.transform.rotation);
                            _temp.GetComponent<Rigidbody>().AddForce(_temp.transform.forward * bulletSpeed);
                            _temp.GetComponent<INFO>().damage = damage;

                            makeSound();
                        }
                    }
                }
                else if (!shotGun)
                {
                    if (Shoot.action.IsPressed() && Time.time > shotTime + shootRate)
                    {
                        if (curAmmo != 0)
                        {
                            curAmmo--;
                            shotTime = Time.time;
                            GameObject _temp = Instantiate(bullet, firePoint.transform.position, firePoint.transform.rotation);
                            _temp.GetComponent<Rigidbody>().AddForce(_temp.transform.forward * bulletSpeed);
                            _temp.GetComponent<INFO>().damage = damage;

                            makeSound();
                        }
                    }
                }
                else
                {
                    if (Shoot.action.WasPressedThisFrame() && Time.time > shotTime + maxShootRate2)
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
                                _temp.GetComponent<INFO>().damage = damage;

                                makeSound();
                            }
                        }
                    }
                }
            }
        }
    }

    public void makeSound()
    {
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");

        for (int i = 0; i < enemys.Length; i++)
        {
            if (Vector3.Distance(enemys[i].transform.position, transform.position) < soundDistance)
            {
                enemys[i].GetComponent<Enemy>().Hearing(transform.position);
            }
        }
    }
}
