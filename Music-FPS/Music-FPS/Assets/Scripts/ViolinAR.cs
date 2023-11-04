using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViolinAR : Guns
{
    private void Start()
    {
        damage = 20f;
        range = 300f;
        bulletForce = 40f;
        bulletCooldown = 0.1f;
        fov = 60f;
        zoomScale = 0.65f;
    }
}
