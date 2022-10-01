using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    [Header("Pickup System")]
    public SphereCollider col;
    public PlayerMovement playermovement;
    public PlayerInput playerInput;
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

    public void Awake()
    {
        col = this.GetComponent<SphereCollider>();
    }
    // Start is called before the first frame update
    public void Start()
    {
        playerInput = playermovement.playerInput;
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
        if (playerInput.Player_Map.Throw.WasPressedThisFrame())
        {
            if (currentWeapon != null)
            {
                GameObject _temp2 = Instantiate(weapons[currentWeapon.GetComponent<ID>().weaponID], spawnPosition.position, spawnPosition.rotation);
                _temp2.GetComponent<ID>().pickup = true;
                _temp2.GetComponent<Rigidbody>().AddForce(transform.forward * Random.Range(minForce, maxForce));
                _temp2.GetComponent<Rigidbody>().AddTorque(new Vector3(Random.Range(minTorque, maxTorque), Random.Range(minTorque, maxTorque), Random.Range(minTorque, maxTorque)));
                Destroy(currentWeapon);
            }
        }
        if (playerInput.Player_Map.Pickup.WasPressedThisFrame())
        {
            if (items.Count > 0)
            {
                if (currentWeapon != null)
                {
                    GameObject _temp2 = Instantiate(weapons[currentWeapon.GetComponent<ID>().weaponID], spawnPosition.position, spawnPosition.rotation);
                    _temp2.GetComponent<ID>().pickup = true;
                    _temp2.GetComponent<Rigidbody>().AddForce(transform.forward * Random.Range(minForce, maxForce));
                    _temp2.GetComponent<Rigidbody>().AddTorque(new Vector3(Random.Range(minTorque, maxTorque), Random.Range(minTorque, maxTorque), Random.Range(minTorque, maxTorque)));
                    Destroy(currentWeapon);
                }
                GameObject _temp = Instantiate(weapons[items[0].gameObject.GetComponent<ID>().weaponID], spawnPosition);
                _temp.GetComponent<ID>().pickup = false;
                Destroy(_temp.GetComponent<Rigidbody>());
                currentWeapon = _temp;
                Destroy(items[0].gameObject);
                items.RemoveAt(0);
            }
        }

    }
}
