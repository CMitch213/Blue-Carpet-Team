using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tambourine : MonoBehaviour
{
    [Header("Stats")]
    public float damage;
    public float range;
    public float bulletForce;
    public float bulletCooldown;
    public float bulletTimer;
    public AudioSource shootSound;

    [Header("Raycast Stuff")]
    public Camera cam;

    [Header("Everything Else")]
    public GameObject hitLoc;
    public GameObject bloodSplat;
    public bool canShoot = true;
    public Slider slider;

    private void Start()
    {
        damage = 200f;
        range = 3.5f;
        bulletForce = 350f;
        bulletCooldown = 0.3f;
    }

    // Update is called once per frame
    void Update()
    {
        if (bulletTimer >= bulletCooldown)
        {
            canShoot = true;
        }

        slider.maxValue = bulletCooldown;
        slider.value = bulletTimer;

        //If player left clicks shoot the gun
        if (Input.GetMouseButtonDown(0) && canShoot)
        {
            Stab();
        }
    }

    private void FixedUpdate()
    {
        if (bulletTimer <= bulletCooldown)
        {
            bulletTimer += Time.deltaTime;
        }
    }

    public void Stab()
    {
        //Where I hit
        RaycastHit hit;

        bulletTimer = 0f;
        canShoot = false;
        shootSound.Play();
        //Do I hit something?
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            Enemy enemy = hit.transform.GetComponent<Enemy>();

            if (enemy != null)
            {
                enemy.Damage(damage);
                GameObject bloodEffect = Instantiate(bloodSplat, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(bloodEffect, 2f);
            }
            else
            {
                GameObject hitEffect = Instantiate(hitLoc, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(hitEffect, 2f);
            }
            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * bulletForce);
            }
        }
    }
}
