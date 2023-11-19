using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Apply this Script to any thing to make it have health and be able to be killed.
    [Header("Stats")]
    public float health;

    public void Damage(float amountOfDmg)
    {
        health -= amountOfDmg;
        Debug.Log("Enemy health = " + health);
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
