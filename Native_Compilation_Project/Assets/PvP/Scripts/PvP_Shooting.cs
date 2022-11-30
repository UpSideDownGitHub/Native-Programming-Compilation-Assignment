using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using Unity.VisualScripting;
//using UnityEngine.InputSystem.iOS;
//using System.Diagnostics.CodeAnalysis;

public class PvP_Shooting : MonoBehaviour
{
    [Header("Effects")]
    public Camera cam;
    public GameObject shotParticle;
    public float camShakeDuration = 0.45f;
    public float camShakeStrength = 5f;
    public float shakeAmmount = 0.1f;
    [Range(0, 1)]
    public float strength = 0.5f;
    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip clip;

    [Header("Ammo Count")]
    public TMP_Text ammoText;

    [Header("Bullet")]
    public float damage;
    [Range(0,1)]
    public int bulletID;

    [Header("Shooting")]
    public GameObject firePoint;
    public GameObject bullet;
    public float bulletSpeed;

    [Header("Ammo")]
    public int maxAmmo;
    public int curAmmo;
    public int maxHeldAmmo;
    public int curHeldAmmo;
    public float reloadTime;
    public float timeOfLastShot;
    public bool reloading;


    [Header("Type")]
    public bool manual;
    public bool shotGun;

    private float shotTime;
    public float maxShootRate;

    [Header("Shotgun")]
    public int bulletAmmout;
    public float deviation;

    private GameManager gameManager;

    public void Start()
    {
        curAmmo = maxAmmo;
        curHeldAmmo = maxHeldAmmo;
    }

    public void OnEnable()
    {
        //ammoText = GameObject.FindGameObjectWithTag("Ammo_Count").GetComponent<TMP_Text>();
        shotTime = 0;
        timeOfLastShot = 0;
        reloading = false;

    }

    public void ShootHeld()
    {
        if (shotGun || manual)
            return;
        if (reloading)
        {
            if (Time.time > reloadTime + timeOfLastShot)
            {
                // reload complete
                reloading = false;
                if (curHeldAmmo >= 0)
                {
                    if (curHeldAmmo >= maxAmmo)
                    {
                        curAmmo = maxAmmo;
                        curHeldAmmo -= maxAmmo;
                    }
                    else
                    {
                        curAmmo = curHeldAmmo;
                        curHeldAmmo = 0;
                    }
                }
            }
        }
        else if (!shotGun && !manual)
        {
            if (Time.time > shotTime + maxShootRate)
            {
                if (curAmmo > 0)
                {
                    curAmmo--;

                    if (curAmmo <= 0)
                    {
                        reloading = true;
                        timeOfLastShot = Time.time;
                    }

                    shotTime = Time.time;
                    GameObject _temp = Instantiate(bullet, firePoint.transform.position, firePoint.transform.rotation);
                    _temp.GetComponent<Rigidbody>().AddForce(_temp.transform.forward * bulletSpeed);
                    _temp.GetComponent<INFO>().damage = damage;
                    _temp.GetComponent<INFO>().meleeID = bulletID;
                    //ammoText.text = curAmmo + "/" + GetComponent<ID>().maxAmmo;

                    GameObject particle = Instantiate(shotParticle, firePoint.transform.position, firePoint.transform.rotation);
                    Destroy(particle, 1);

                    cam.gameObject.GetComponent<CameraShake>().cameraShake(camShakeDuration, camShakeStrength);

                    StartCoroutine(controllerShake());

                    audioSource.PlayOneShot(clip);

                    //gameManager.shots++;
                }
                else
                {
                    reloading = true;
                    timeOfLastShot = Time.time;
                }
            }
        }
    }

    // Update is called once per frame
    public void ShootPressed()
    {
        if (!shotGun && !manual)
            return;
        if (reloading)
        {
            if (Time.time > reloadTime + timeOfLastShot)
            {
                // reload complete
                reloading = false;
                if (curHeldAmmo >= 0)
                {
                    if (curHeldAmmo >= maxAmmo)
                    {
                        curAmmo = maxAmmo;
                        curHeldAmmo -= maxAmmo;
                    }
                    else
                    {
                        curAmmo = curHeldAmmo;
                        curHeldAmmo = 0;
                    }
                }
            }
        }
        else if (manual)
        {
            if (Time.time > shotTime + maxShootRate)
            {
                if (curAmmo > 0)
                {
                    curAmmo--;

                    if (curAmmo <= 0)
                    {
                        reloading = true;
                        timeOfLastShot = Time.time;
                    }

                    shotTime = Time.time;
                    GameObject _temp = Instantiate(bullet, firePoint.transform.position, firePoint.transform.rotation);
                    _temp.GetComponent<Rigidbody>().AddForce(_temp.transform.forward * bulletSpeed);
                    _temp.GetComponent<INFO>().damage = damage;
                    _temp.GetComponent<INFO>().meleeID = bulletID;
                    //ammoText.text = curAmmo + "/" + GetComponent<ID>().maxAmmo;

                    GameObject particle = Instantiate(shotParticle, firePoint.transform.position, firePoint.transform.rotation);
                    Destroy(particle, 1);

                    cam.gameObject.GetComponent<CameraShake>().cameraShake(camShakeDuration, camShakeStrength);

                    StartCoroutine(controllerShake());

                    audioSource.PlayOneShot(clip);

                    //gameManager.shots++;
                }
                else
                {
                    reloading = true;
                    timeOfLastShot = Time.time;
                }
            }
        }
        else if (!shotGun)
        {
            if (Time.time > shotTime + maxShootRate)
            {
                if (curAmmo > 0)
                {
                    curAmmo--;

                    if (curAmmo <= 0)
                    {
                        reloading = true;
                        timeOfLastShot = Time.time;
                    }

                    shotTime = Time.time;
                    GameObject _temp = Instantiate(bullet, firePoint.transform.position, firePoint.transform.rotation);
                    _temp.GetComponent<Rigidbody>().AddForce(_temp.transform.forward * bulletSpeed);
                    _temp.GetComponent<INFO>().damage = damage;
                    _temp.GetComponent<INFO>().meleeID = bulletID;
                    //ammoText.text = curAmmo + "/" + GetComponent<ID>().maxAmmo;

                    GameObject particle = Instantiate(shotParticle, firePoint.transform.position, firePoint.transform.rotation);
                    Destroy(particle, 1);

                    cam.gameObject.GetComponent<CameraShake>().cameraShake(camShakeDuration, camShakeStrength);

                    StartCoroutine(controllerShake());

                    audioSource.PlayOneShot(clip);

                    //gameManager.shots++;
                }
                else
                {
                    reloading = true;
                    timeOfLastShot = Time.time;
                }
            }
        }
        else
        {
            if (Time.time > shotTime + maxShootRate)
            {
                if (curAmmo > 0)
                {
                    curAmmo--;

                    if (curAmmo <= 0)
                    {
                        reloading = true;
                        timeOfLastShot = Time.time;
                    }

                    shotTime = Time.time;
                    for (int i = 0; i < bulletAmmout; i++)
                    {
                        Quaternion _rot = new Quaternion(firePoint.transform.rotation.x, firePoint.transform.rotation.y + Random.Range(-deviation, deviation), firePoint.transform.rotation.z, firePoint.transform.rotation.w + Random.Range(-deviation, deviation));
                        GameObject _temp = Instantiate(bullet, firePoint.transform.position, _rot);
                        _temp.GetComponent<Rigidbody>().AddForce(_temp.transform.forward * bulletSpeed);
                        _temp.GetComponent<INFO>().damage = damage;
                        _temp.GetComponent<INFO>().meleeID = bulletID;
                    }

                    GameObject particle = Instantiate(shotParticle, firePoint.transform.position, firePoint.transform.rotation);
                    Destroy(particle, 1);

                    cam.gameObject.GetComponent<CameraShake>().cameraShake(camShakeDuration, camShakeStrength);


                    audioSource.PlayOneShot(clip);

                    //gameManager.shots++;

                    StartCoroutine(controllerShake());

                    //ammoText.text = curAmmo + "/" + GetComponent<ID>().maxAmmo;
                }
                else
                {
                    reloading = true;
                    timeOfLastShot = Time.time;
                }
            }
        }
    }

    public IEnumerator controllerShake()
    {
        Gamepad.current.SetMotorSpeeds(strength, strength);
        yield return new WaitForSeconds(shakeAmmount);
        Gamepad.current.ResetHaptics();
    }
}
