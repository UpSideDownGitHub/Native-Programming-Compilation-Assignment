using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private NavMeshAgent _agent;
    private GameObject _player;

    [Header("Nav Mesh Agent")]
    public float speed = 3.5f;
    public float angularSpeed = 120;
    public float acceleration = 8;
    public float stoppingDistance = 1;
    public bool autoBreak = true;
    
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _agent = GetComponent<NavMeshAgent>();

        _agent.speed = speed;
        _agent.angularSpeed = angularSpeed;
        _agent.acceleration = acceleration;
        _agent.stoppingDistance = stoppingDistance;
        _agent.autoBraking = autoBreak;
    }

    // Update is called once per frame
    void Update()
    {
        if (_player != null)
        {
            _agent.SetDestination(_player.transform.position);
        }
    }
}
