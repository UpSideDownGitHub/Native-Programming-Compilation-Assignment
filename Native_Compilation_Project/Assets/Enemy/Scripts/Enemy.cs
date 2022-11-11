using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [Header("########## PLAYER ##########")]
    private NavMeshAgent _agent;
    public GameObject _player;

    [Header("########## VISUALS ##########")]
    public GameObject shotParticleEffect;

    [Header("########## MOVEMENT ##########")]
    public bool stop;
    [Header("Nav Mesh Agent")]
    public float speed = 3.5f;
    public float angularSpeed = 120;
    public float acceleration = 8;
    public float stoppingDistance = 1;
    public bool autoBreak = true;
    public bool canRotate = false;
    [Header("Player Tracking")]
    public Vector3 playerLastKnowPosition;
    public bool seenPlayer = false;
    public bool followingPlayer = false;
    [Header("--------------------")]
    [Header("Path Following")]
    public Vector3[] path = new Vector3[0];
    public int currentPoint = 0;
    public float distanceToPoint = 0.1f;
    public float wanderingStoppingDistance = 0;

    [Header("########## SOUND ##########")]
    public AudioSource audioSource;
    public AudioClip audioClip;

    [Header("########## ATTACK ##########")]
    public float attackDistance;
    public float maxShootRate;
    private float shotTime;
    public float damage;
    [Header("--------------------")]
    [Header("Cone Of Vision")]
    public float minSightAngle = 45;
    public float maxSightDistance = 10;
    private int layerMask;


    [Header("--------------------")]
    [Header("Melee Attack")]
    public bool melee;
    public float meleeAttackDistance;
    public float minAngle = 20;
    public float meleeStoppingDistance = 1;
    [Header("--------------------")]
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
        stop = false;
        _player = GameObject.FindGameObjectWithTag("Player");
        _agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        curAmmo = maxAmmo;
        _agent.speed = speed;
        _agent.angularSpeed = angularSpeed;
        _agent.acceleration = acceleration;
        _agent.stoppingDistance = stoppingDistance;
        _agent.autoBraking = autoBreak;

        layerMask = 1 << 2;
        layerMask = ~layerMask;
    }

    // Update is called once per frame
    void Update()
    {
        if (!stop)
        {
            // CALCULATE ANGLE TO PLAYER
            Vector3 targetDir = _player.transform.position - transform.position;
            float angle = Vector3.Angle(targetDir, transform.forward);

            canRotate = false;
            if (Vector3.Distance(_player.transform.position, transform.position) < stoppingDistance)
                canRotate = true;

            // IF ANGLE WITHING ALLOWED RANGE
            if (angle < minSightAngle || canRotate)
            {
                // CHECK IF THERE IS A LINE OF SIGHT TO THE PLAYER
                RaycastHit hit;
                //Debug.DrawRay(transform.position, _player.transform.position - transform.position, Color.red, 2);
                if (Physics.Raycast(transform.position, targetDir, out hit, maxSightDistance, layerMask))
                {

                    // IF THERE IS A LINE OF SIGHT TO THE PLAYER
                    if (hit.transform.gameObject.tag == "Player")
                    {
                        //Debug.Log(hit.transform);
                        followingPlayer = true;

                        // MOVE TO PLAYER POSITION
                        seenPlayer = true;
                        playerLastKnowPosition = _player.transform.position;

                        _agent.stoppingDistance = stoppingDistance;
                        if (melee)
                            _agent.stoppingDistance = meleeStoppingDistance;

                        _agent.SetDestination(playerLastKnowPosition);

                        if (canRotate)
                        {
                            Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDir, 1, 1);
                            transform.rotation = Quaternion.LookRotation(newDirection);
                        }


                        // ATTACK
                        if (Vector3.Distance(transform.position, _player.transform.position) < attackDistance)
                        {
                            if (Time.time > shotTime + maxShootRate)
                            {
                                shotTime = Time.time;
                                shoot();
                            }
                        }
                    }
                    else
                        followingPlayer = false;
                }
                else
                    followingPlayer = false;
            }
            else
                followingPlayer = false;

            // MOVE TO THE PLAYERS LAST KWNO POSITION (WHERE YOU LAST SAW/HEARD THE PLAYER)
            if (seenPlayer && !followingPlayer)
            {
                if (Vector3.Distance(transform.position, playerLastKnowPosition) > 1)
                    _agent.SetDestination(playerLastKnowPosition);
                else
                    seenPlayer = false;
            }
            // MOVE TO THE ORIGNAL POSITION AND CONTINUE WANDERING
            else if (!followingPlayer)
            {
                _agent.stoppingDistance = wanderingStoppingDistance;
                _agent.SetDestination(path[currentPoint]);
                if (Vector3.Distance(transform.position, path[currentPoint]) < distanceToPoint)
                {
                    currentPoint++;
                    if (currentPoint == path.Length)
                        currentPoint = 0;
                }
            }
        }
        else
        {
            _agent.isStopped = true;
        }
    }

    public void Hearing(Vector3 pos)
    {
        seenPlayer = true;
        playerLastKnowPosition = pos;
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
                    audioSource.PlayOneShot(audioClip);
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
                        Physics.IgnoreCollision(_temp.GetComponent<Collider>(), _player.GetComponent<PickupColliderID>().col);
                    }
                    audioSource.PlayOneShot(audioClip);
                    GameObject particle = Instantiate(shotParticleEffect, firePoint.transform.position, firePoint.transform.rotation);
                    Destroy(particle, 2);
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
                    Physics.IgnoreCollision(_temp.GetComponent<Collider>(), _player.GetComponent<PickupColliderID>().col);

                    GameObject particle = Instantiate(shotParticleEffect, firePoint.transform.position, firePoint.transform.rotation);
                    Destroy(particle, 2);

                    audioSource.PlayOneShot(audioClip);
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
