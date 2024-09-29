using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBounce : MonoBehaviour
{
    public float bounceForce = 10f; // Adjust this value to change the bounciness
    public float initialSpeed = 5f; // Adjust this value to change the initial speed
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Generate a random direction
        Vector3 randomDirection = new Vector3(
            Random.Range(-1f, 1f),
            Random.Range(-1f, 1f),
            Random.Range(-1f, 1f)
        ).normalized;

        // Apply the initial velocity
        rb.velocity = randomDirection * initialSpeed;
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with a wall
        if (collision.gameObject.tag == "Wall")
        {
            // Calculate the reflection vector
            Vector3 reflectionVector = Vector3.Reflect(rb.velocity, collision.contacts[0].normal);

            // Apply the bounce force
            rb.velocity = reflectionVector * bounceForce;
        }
    }
}