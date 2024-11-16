using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBehavior : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float movementTime = 25f;

    private Rigidbody rb;
    private float timePassed;
    private Vector3 movement;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        movement = RandomMovementDirection();
        timePassed = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;

        if (timePassed > movementTime)
        {
            movement = RandomMovementDirection();
            timePassed = 0f;
        }

        // Apply movement using Rigidbody
        rb.velocity = movement * moveSpeed;
    }

    Vector3 RandomMovementDirection()
    {
        float x = Random.Range(-1.0f, 1.0f);
        float z = Random.Range(-1.0f, 1.0f);
        return new Vector3(x, 0, z).normalized; // Ensure the vector is normalized
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Stop movement on collision with the player
            movement = Vector3.zero;
        }
    }
}
