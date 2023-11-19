using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowAI : MonoBehaviour
{
    //Apply this script to anything to make it follow the player
    public float moveSpeed; 
    private Transform player; 
    private Rigidbody rb; 
    public float visionDistance;

    void Start()
    {
        // Find the player GameObject by its tag
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        //If you can see player go towards them.
        if (distanceToPlayer < visionDistance)
        {
            Vector3 moveDirection = (player.position - transform.position).normalized;
            rb.MovePosition(transform.position + moveDirection * moveSpeed * Time.deltaTime);
        }
    }
}
