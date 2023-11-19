using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FluteSniper : Guns
{
    public GameObject sniperScope;
    public CameraMovement cameraMove;

    // Start is called before the first frame update
    private void Start()
    {
        damage = 100f;
        range = 3000f;
        bulletForce = 750f;
        bulletTimer = 1.2f;
        bulletCooldown = 1.2f;
        fov = 60f;
        zoomScale = 0.2f;
    }

    void Update()
    {
        if (bulletTimer >= bulletCooldown)
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
            camMove.xSens = camMove.xSens / 5;
            camMove.ySens = camMove.ySens / 5;
            sniperScope.SetActive(true);
            camMove.buttonCrossHair.SetActive(false);
        }
        if (Input.GetMouseButtonUp(1))
        {
            cam.fieldOfView = fov;
            camMove.buttonCrossHair.SetActive(true);
            camMove.buttonCrossHair.transform.localScale = new Vector3(2.0f, 2.0f, 2.0f);
            sniperScope.SetActive(false);
            camMove.xSens = camMove.xSens * 5;
            camMove.ySens = camMove.ySens * 5;
        }
    }
}
