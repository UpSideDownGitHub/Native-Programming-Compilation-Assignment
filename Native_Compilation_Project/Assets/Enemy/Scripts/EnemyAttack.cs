using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAttack : MonoBehaviour
{
    [Header("Player")]
    private NavMeshAgent _agent;
    private GameObject _player;

    [Header("Attack")]
    public float attackDistance;
    public float maxShootRate;
    private float shotTime;
    public float damage;

    [Header("Melee Attack")]
    public bool melee;
    public float meleeAttackDistance;
    public float minAngle = 20;
    public float meleeStoppingDistance = 1;

    [Header("Range Attack")]
    public bool auto;
    public bool shotGun;
    public GameObject firePoint;
    public GameObject bullet;
    public int maxAmmo;
    public int curAmmo;
    public float bulletSpeed;
    [Header("ShotGun")]
    public int bulletAmmout;
    public float deviation;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _agent = GetComponent<NavMeshAgent>();
        curAmmo = maxAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, _player.transform.position) < attackDistance)
        {
            if (Time.time > shotTime + maxShootRate)
            {
                shotTime = Time.time;
                shoot();        
            }
        }
    }

    public void shoot()
    {
        if (melee)
        {
            if (Vector3.Distance(_player.transform.position, transform.position) < meleeAttackDistance + 1)
            {
                Vector3 targetDir = _player.transform.position - transform.position;
                float angle = Vector3.Angle(targetDir, transform.forward);

                if (angle < minAngle)
                {
                    _player.GetComponent<Health>().changeHealth(-damage);
                }
            }
        }
        else
        {
            if (shotGun)
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
                    }
                }
                else
                {
                    melee = true;
                    _agent.stoppingDistance = meleeStoppingDistance;
                    attackDistance = meleeAttackDistance;
                }
            }
            else
            {
                if (curAmmo != 0)
                {
                    curAmmo--;
                    shotTime = Time.time;
                    GameObject _temp = Instantiate(bullet, firePoint.transform.position, firePoint.transform.rotation);
                    _temp.GetComponent<Rigidbody>().AddForce(_temp.transform.forward * bulletSpeed);
                    _temp.GetComponent<INFO>().damage = damage;
                }
                else
                {
                    melee = true;
                    _agent.stoppingDistance = meleeStoppingDistance;
                    attackDistance = meleeAttackDistance;
                }
            }
        }
    }
}
