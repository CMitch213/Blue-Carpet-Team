using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    Rigidbody _rb;
    
    [Header("IDK What To Call This")]
    public float speed = 0.01f;
    public GameObject explosion;
    //private float _trailRate = 200;
    //private GameObject _smokeTrail;

    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(explosion, transform.TransformPoint(0f, 0f, 0f), transform.rotation);
        Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        //_smokeTrail.SetActive(true);
        Vector3 forward = _rb.transform.forward;
        _rb.AddForce(forward * speed, ForceMode.Impulse);
    }
}
