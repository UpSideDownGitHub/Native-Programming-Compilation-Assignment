using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class WeaponPickup : MonoBehaviour
{
    [Header("Pickup System")]
    public SphereCollider col;
    public PlayerMovement playermovement;
    public PlayerInput playerInput;
    public InputActionReference ThrowWeapon;
    public InputActionReference Pickup;
    public Transform spawnPosition;
    private List<GameObject> items = new List<GameObject>();


    [Header("Weapons")]
    public GameObject[] weapons;
    public GameObject currentWeapon;


    [Header("Throwing Old Weapon")]
    public float maxForce;
    public float minForce;
    public float maxTorque;
    public float minTorque;

    [Header("Fists")]
    public GameObject fists;

    [Header("Ammo UI")]
    public TMP_Text ammoText;

    [Header("Sound")]
    public AudioSource audioSource;
    public AudioClip audioClip;

    public void Awake()
    {
        col = this.GetComponent<SphereCollider>();
    }
    // Start is called before the first frame update
    public void Start()
    {
        playerInput = playermovement.playerInput;
        fists.SetActive(true);
        ammoText.text = "";
    }

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag.Equals("PICKUP"))
        {
            if (collision.gameObject.GetComponent<ID>().pickup)
            {
                items.Add(collision.gameObject);  
            }
        }
    }
    public void OnTriggerExit(Collider other)
    {
        items.Remove(other.gameObject);
    }
    // Update is called once per frame
    public void Update()
    {
        if (ThrowWeapon.action.WasPressedThisFrame())
        {
            if (currentWeapon != null)
            {
                GameObject _temp2 = Instantiate(weapons[currentWeapon.GetComponent<ID>().weaponID], spawnPosition.position, spawnPosition.rotation);
                _temp2.GetComponent<ID>().curAmmo = currentWeapon.GetComponent<Shooting>().curAmmo;
                _temp2.GetComponent<ID>().pickup = true;
                _temp2.GetComponent<Rigidbody>().AddForce(transform.forward * Random.Range(minForce, maxForce));
                _temp2.GetComponent<Rigidbody>().AddTorque(new Vector3(Random.Range(minTorque, maxTorque), Random.Range(minTorque, maxTorque), Random.Range(minTorque, maxTorque)));
                Destroy(currentWeapon);
                currentWeapon = null;
                fists.SetActive(true);
                audioSource.PlayOneShot(audioClip, PlayerPrefs.GetFloat("SFXVolume", 0));
                ammoText.text = "Fist";

            }
        }
        if (Pickup.action.WasPressedThisFrame())
        {
            if (items.Count > 0)
            {
                fists.SetActive(false);
                // throw old weapon
                if (currentWeapon != null)
                {
                    GameObject _temp2 = Instantiate(weapons[currentWeapon.GetComponent<ID>().weaponID], spawnPosition.position, spawnPosition.rotation);
                    _temp2.GetComponent<ID>().curAmmo = currentWeapon.GetComponent<Shooting>().curAmmo;
                    _temp2.GetComponent<ID>().pickup = true;
                    _temp2.GetComponent<Rigidbody>().AddForce(transform.forward * Random.Range(minForce, maxForce));
                    _temp2.GetComponent<Rigidbody>().AddTorque(new Vector3(Random.Range(minTorque, maxTorque), Random.Range(minTorque, maxTorque), Random.Range(minTorque, maxTorque)));
                    Destroy(currentWeapon);
                    audioSource.PlayOneShot(audioClip, PlayerPrefs.GetFloat("SFXVolume", 0));

                }
                // spawning new weapon
                GameObject _temp = Instantiate(weapons[items[0].gameObject.GetComponent<ID>().weaponID], spawnPosition);
                _temp.GetComponent<ID>().pickup = false;
                Destroy(_temp.GetComponent<Rigidbody>());
                currentWeapon = _temp;
                currentWeapon.GetComponent<Shooting>().curAmmo = items[0].gameObject.GetComponent<ID>().curAmmo;
                Destroy(items[0].gameObject);
                items.RemoveAt(0);

                // update UI to show new ammo count
                // if melee weapon
                if (_temp.GetComponent<ID>().weaponID == 3)
                    ammoText.text = "Fist";
                else if(_temp.GetComponent<ID>().weaponID == 4)
                    ammoText.text = "Knife";
                else if (_temp.GetComponent<ID>().weaponID == 5)
                    ammoText.text = "Bat";
                // ranged weapon
                else
                {
                    ammoText.text = currentWeapon.GetComponent<Shooting>().curAmmo.ToString() + "/" + _temp.GetComponent<ID>().maxAmmo.ToString();
                }
            }
        }
    }

    public void giveWeapon(int wepaonID)
    {
        fists.SetActive(false);
        // throw old weapon
        if (currentWeapon != null)
        {
            GameObject _temp2 = Instantiate(weapons[currentWeapon.GetComponent<ID>().weaponID], spawnPosition.position, spawnPosition.rotation);
            _temp2.GetComponent<ID>().curAmmo = currentWeapon.GetComponent<Shooting>().curAmmo;
            _temp2.GetComponent<ID>().pickup = true;
            _temp2.GetComponent<Rigidbody>().AddForce(transform.forward * Random.Range(minForce, maxForce));
            _temp2.GetComponent<Rigidbody>().AddTorque(new Vector3(Random.Range(minTorque, maxTorque), Random.Range(minTorque, maxTorque), Random.Range(minTorque, maxTorque)));
            Destroy(currentWeapon);
            audioSource.PlayOneShot(audioClip, PlayerPrefs.GetFloat("SFXVolume", 0));

        }
        // spawning new weapon
        GameObject _temp = Instantiate(weapons[wepaonID], spawnPosition);
        _temp.GetComponent<ID>().pickup = false;
        Destroy(_temp.GetComponent<Rigidbody>());
        currentWeapon = _temp;
        currentWeapon.GetComponent<Shooting>().curAmmo = _temp.GetComponent<ID>().maxAmmo;

        // update UI to show new ammo count
        // if melee weapon
        if (_temp.GetComponent<ID>().weaponID == 3)
            ammoText.text = "Fist";
        else if (_temp.GetComponent<ID>().weaponID == 4)
            ammoText.text = "Knife";
        else if (_temp.GetComponent<ID>().weaponID == 5)
            ammoText.text = "Bat";
        // ranged weapon
        else
        {
            ammoText.text = currentWeapon.GetComponent<Shooting>().curAmmo.ToString() + "/" + _temp.GetComponent<ID>().maxAmmo.ToString();
        }
    }
}


/*
 * 0 - Pistol
 * 1 - Assult
 * 2 - Shotgun
 * 3 - Fist
 * 4 - Knife
 * 5 - Bat
*/