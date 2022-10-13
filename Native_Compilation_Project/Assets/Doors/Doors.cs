using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    public float minRotation = -45;
    public float maxRotation = 200;

    private Vector3 _pos;
    private Rigidbody _rb; 
    // Start is called before the first frame update
    void Start()
    {
        _pos = this.transform.position;
        _rb = GetComponent<Rigidbody>();
        _rb.centerOfMass = new Vector3(0, 0, -_rb.transform.localScale.z / 2);
    }

    public void Update()
    {

    }
}
