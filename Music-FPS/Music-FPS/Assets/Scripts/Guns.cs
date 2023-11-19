using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Guns : MonoBehaviour
{
    [Header("Stats")]
    public float damage;
    public float range;
    public float bulletForce;
    public float bulletCooldown;
    public float bulletTimer;
    public AudioSource shootSound;
    //public Animation recoil;


    [Header("Raycast Stuff")]
    public Camera cam;

    [Header("Everything Else")]
    public ParticleSystem muzzleFlash;
    public GameObject hitLoc;
    public GameObject bloodSplat;
    public bool canShoot = true;
    public Slider slider;
    PlayerControls controls;

    [Header("ADS")]
    public float fov;
    public float zoomScale; /*Lower Number = More zoomed*/
    public CameraMovement camMove;

    // Start is called before the first frame update
    void Start()
    {
        controls = new PlayerControls();
        cam.fieldOfView = fov;
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

        slider.maxValue = bulletCooldown;
        slider.value = bulletTimer;

        //ADS
        if (Input.GetMouseButtonDown(1))
        {
            cam.fieldOfView = fov * zoomScale;
            camMove.buttonCrossHair.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        }
        if (Input.GetMouseButtonUp(1))
        {
            cam.fieldOfView = fov;
            camMove.buttonCrossHair.transform.localScale = new Vector3(2.0f, 2.0f, 2.0f);
        }

        //Controller Input

        //Shoot
        if (canShoot)
        {
            controls.Gameplay.Shoot.performed += ctx => Shoot();
        }

        //ADS
        controls.Gameplay.ADS.performed += ctx => ADS();
        controls.Gameplay.ADS.canceled += ctx => UnADS();
    }

    private void FixedUpdate()
    {
        if(bulletTimer <= bulletCooldown)
        {
            bulletTimer += Time.deltaTime;
        }
    }

    public void Shoot()
    {
        //Where I hit
        RaycastHit hit;

        bulletTimer = 0f;
        canShoot = false;
        muzzleFlash.Play();
        shootSound.Play();
        //recoil.Play();
        //Do I hit something?
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {   
            Debug.Log(hit.transform.name);
            Enemy enemy = hit.transform.GetComponent<Enemy>();
            
            if(enemy != null)
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
        //recoil.Stop();
    }

    //Controller Methods

    //ADS
    void ADS()
    {
        cam.fieldOfView = fov * zoomScale;
        camMove.buttonCrossHair.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
    }
    void UnADS()
    {
        cam.fieldOfView = fov;
        camMove.buttonCrossHair.transform.localScale = new Vector3(2.0f, 2.0f, 2.0f);
    }

}
