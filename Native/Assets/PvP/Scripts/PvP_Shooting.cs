using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using Unity.VisualScripting;

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
    private bool _once = true;


    [Header("Type")]
    public bool manual;
    public bool shotGun;

    private float shotTime;
    public float maxShootRate;

    [Header("Shotgun")]
    public int bulletAmmout;
    public float deviation;

    private GameManager gameManager;

    [Header("UI")]
    public PvP_UIManager uiManager;

    [Header("End Screen")]
    public int shots;


    public void Start()
    {
        resetAmmo();
    }

    public void resetAmmo()
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
        uiManager = GameObject.FindGameObjectWithTag("PvP_UIManager").GetComponent<PvP_UIManager>();
    }

    public void Update()
    {
        if (reloading && Time.time > reloadTime + timeOfLastShot)
        {
            // reload complete
            reloading = false;
            if (curHeldAmmo > 0)
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
            else if (_once)
            {
                Debug.Log("TEST");
                _once = false;
                // this weapon is out of ammo
                gameObject.GetComponentInParent<PvP_Health>().lostAllAmmo();
            }
            if (bulletID == 0)
                uiManager.updateP1AmmoUI();
            else
                uiManager.updateP2AmmoUI();
        }
    }

    public void ShootHeld()
    {
        if (shotGun || manual)
            return;
        if (reloading)
        {
            return;
        }
        else if (!shotGun && !manual)
        {
            if (Time.time > shotTime + maxShootRate)
            {
                if (curAmmo > 0)
                {
                    curAmmo--;
                    if (bulletID == 0)
                    { 
                        uiManager.updateP1AmmoUI();
                        PvP_StatsCollector.Instance.P1Shots++;
                    }
                    else
                    {
                        uiManager.updateP2AmmoUI();
                        PvP_StatsCollector.Instance.P2Shots++;
                    }

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

                    //StartCoroutine(controllerShake());

                    audioSource.PlayOneShot(clip, PlayerPrefs.GetFloat("SFXVolume", 0));

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
            return;
        }
        else if (manual)
        {
            if (Time.time > shotTime + maxShootRate)
            {
                if (curAmmo > 0)
                {
                    curAmmo--;

                    if (bulletID == 0)
                    {
                        uiManager.updateP1AmmoUI();
                        PvP_StatsCollector.Instance.P1Shots++;
                    }
                    else
                    {
                        uiManager.updateP2AmmoUI();
                        PvP_StatsCollector.Instance.P2Shots++;
                    }

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

                    //StartCoroutine(controllerShake());

                    audioSource.PlayOneShot(clip, PlayerPrefs.GetFloat("SFXVolume", 0));

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

                    if (bulletID == 0)
                    {
                        uiManager.updateP1AmmoUI();
                        PvP_StatsCollector.Instance.P1Shots++;
                    }
                    else
                    {
                        uiManager.updateP2AmmoUI();
                        PvP_StatsCollector.Instance.P2Shots++;
                    }

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

                    //StartCoroutine(controllerShake());

                    audioSource.PlayOneShot(clip, PlayerPrefs.GetFloat("SFXVolume", 0));

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

                    if (bulletID == 0)
                    {
                        uiManager.updateP1AmmoUI();
                        PvP_StatsCollector.Instance.P1Shots++;
                    }
                    else
                    {
                        uiManager.updateP2AmmoUI();
                        PvP_StatsCollector.Instance.P2Shots++;
                    }

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


                    audioSource.PlayOneShot(clip, PlayerPrefs.GetFloat("SFXVolume", 0));

                    //gameManager.shots++;

                    //StartCoroutine(controllerShake());

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
}
