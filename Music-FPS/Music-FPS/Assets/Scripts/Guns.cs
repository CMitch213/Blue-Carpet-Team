using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guns : MonoBehaviour
{
    [Header("Stats")]
    public float damage;
    public float range;
    public float bulletForce;
    public float bulletCooldown;
    public float bulletTimer;

    [Header("Raycast Stuff")]
    public Camera cam;

    [Header("Everything Else")]
    public ParticleSystem muzzleFlash;
    public GameObject hitLoc;
    public bool canShoot = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(bulletTimer >= bulletCooldown)
        {
            canShoot = true;
        }
        //If player left clicks shoot the gun
        if (Input.GetMouseButtonDown(0) && canShoot)
        {
            Shoot();
        }
    }

    private void FixedUpdate()
    {
        if(bulletTimer <= bulletCooldown)
        {
            bulletTimer += Time.deltaTime;
        }
    }

    void Shoot()
    {
        //Where I hit
        RaycastHit hit;

        bulletTimer = 0f;
        canShoot = false;
        muzzleFlash.Play();
        //Do I hit something?
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {   
            Debug.Log(hit.transform.name);
            Enemy enemy = hit.transform.GetComponent<Enemy>();
            if(enemy != null)
            {
                enemy.Damage(damage);
            }
            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * bulletForce);
            }

            GameObject hitEffect = Instantiate(hitLoc, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(hitEffect, 2f);
        }
    }
}
