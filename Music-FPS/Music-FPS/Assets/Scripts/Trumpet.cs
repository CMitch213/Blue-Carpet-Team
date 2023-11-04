using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trumpet : Guns
{
    private void Start()
    {
        damage = 10f;
        range = 150f;
        bulletForce = 15f;
        bulletCooldown = 0.25f;
        fov = 60f;
        zoomScale = 0.8f;
    }
}
