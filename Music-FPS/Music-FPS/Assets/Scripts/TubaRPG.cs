using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TubaRPG : MonoBehaviour
{
    [Header("Everything Else")]
    public Slider slider;
    public float bulletCooldown;
    public float bulletTimer;
    public AudioSource shootSound;
    public bool canShoot = true;
    public Camera cam;

    [Header("ADS")]
    public float fov;
    public float zoomScale; /*Lower Number = More zoomed*/
    public CameraMovement camMove;

    [Header("Tuba Stuff")]
    public GameObject missile;
    public GameObject firePoint;

    // Start is called before the first frame update
    void Start()
    {
        bulletCooldown = 1.0f;
        bulletTimer = 0f;
        fov = 60f;
        zoomScale = 0.65f;
    }

    // Update is called once per frame
    void Update()
    {
        if (bulletTimer >= bulletCooldown)
        {
            canShoot = true;
        }
        //If player left clicks shoot the gun
        if (Input.GetMouseButtonDown(0) && canShoot)
        {
            Instantiate(missile, firePoint.transform.position, firePoint.transform.rotation);
            canShoot = false;
            bulletTimer = 0f;
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
    }

    private void FixedUpdate()
    {
        if (bulletTimer <= bulletCooldown)
        {
            bulletTimer += Time.deltaTime;
        }
    }
}
