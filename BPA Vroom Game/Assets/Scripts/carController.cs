using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carController : MonoBehaviour
{
    public float maxSpeed;
    public float acceleration;
    public float steering;

    public Rigidbody2D rb;
    private float currentSpeed;
    private float reverse;

    private void Start()
    {
        this.rb = GetComponent<Rigidbody2D>();
        maxSpeed = 65f;
    }

    private void FixedUpdate()
    {


        // Get input
        float h = -Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // Create car rotation
        float direction = Vector2.Dot(rb.velocity, rb.GetRelativeVector(Vector2.up));
        if (Input.GetKey(KeyCode.Space))
        {
            acceleration = 0;
            reverse = .5f;
            if (h < -.5 || h > .5)
                rb.drag = .1f;

        }
        else if (Input.GetKey(KeyCode.LeftShift) && v > 0) //Boost
        {
            acceleration = 15f;
            maxSpeed = 80f;
        }
        else
        {
            acceleration = 10f;
            reverse = 0;
            rb.drag = 2;
            if (maxSpeed < 65f) //Managing stopping boost
            {
                maxSpeed -= Time.deltaTime * 5;
            }
            else if (maxSpeed > 65f)
            {
                maxSpeed = 65f;
            }
        }
        if (direction >= 0.0f)
        {
            rb.rotation += 2 * h * steering * (rb.velocity.magnitude / maxSpeed);
        }
        else
        {
            rb.rotation -= 2 * h * steering * (rb.velocity.magnitude / maxSpeed);
        }

        // Calculate speed from input and acceleration (transform.up is forward)
        Vector2 speed = transform.up * (v * acceleration - (reverse * v * acceleration));
        rb.AddForce(speed);

        // Change velocity based on rotation
        float driftForce = Vector2.Dot(rb.velocity, rb.GetRelativeVector(Vector2.left)) * 2.0f;
        Vector2 relativeForce = Vector2.right * driftForce;
        Debug.DrawLine(rb.position, rb.GetRelativePoint(relativeForce), Color.green);
        rb.AddForce(rb.GetRelativeVector(relativeForce));

        // Force max speed limit
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
        currentSpeed = rb.velocity.magnitude;

        if (!(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
        {
            rb.angularDrag = 2;
            rb.angularVelocity = 0;
        }
        else
        {
            rb.angularDrag = .05f;
        }

    }

}
