using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubaExplosion : MonoBehaviour
{
    float damage = 200f;
    public float blastRadius = 30f;
    public float explosionForce = 200f;

    private Collider[] hitColliders;

    void OnCollisionEnter(Collision collision)
    {
        DoExplosion(collision.contacts[0].point);
        Destroy(gameObject, 3);
    }
    void Start()
    {
        Destroy(gameObject, 3);
    }

    void DoExplosion(Vector3 explosionPoint)
    {
        hitColliders = Physics.OverlapSphere(explosionPoint, blastRadius);

        foreach (Collider hitcol in hitColliders)
        {
            if(hitcol.GetComponent<Rigidbody>() != null)
            {
                hitcol.GetComponent<Rigidbody>().isKinematic = false;
                hitcol.GetComponent<Rigidbody>().AddExplosionForce(explosionForce, explosionPoint, blastRadius, 8, ForceMode.Impulse);

                //Debug.Log(hitcol.gameObject.name);
                if (hitcol.CompareTag("Enemy"))
                {
                    hitcol.GetComponent<Enemy>().Damage(damage);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
