using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiltFloor : MonoBehaviour
{
    public float tiltSpeed = 20.0f; // Speed at which the floor tilts
    public float maxTiltAngle = 20.0f; // Maximum angle that the floor can tilt
    public float ballForce = 8.0f; // Magnitude of the force applied to the ball
    public float maxBallSpeed = 10.0f; // Maximum speed of the ball

    private Rigidbody floorRigidbody;
    private Vector3 gravityDirection;
    private Rigidbody ballRigidbody;

    void Start()
    {
        floorRigidbody = GetComponent<Rigidbody>();
        gravityDirection = Physics.gravity.normalized;
        ballRigidbody = GameObject.FindGameObjectWithTag("Ball").GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float tiltX = Input.GetAxis("Horizontal");
        float tiltZ = Input.GetAxis("Vertical");

        // Calculate the new rotation of the floor based on user input
        Quaternion targetRotation = Quaternion.Euler(maxTiltAngle * tiltZ, 0, maxTiltAngle * -tiltX);
        floorRigidbody.MoveRotation(Quaternion.RotateTowards(floorRigidbody.rotation, targetRotation, tiltSpeed * Time.fixedDeltaTime));

        // Calculate the movement direction of the ball based on the floor angle and gravity direction
        Vector3 ballMovementDirection = Quaternion.FromToRotation(gravityDirection, transform.up) * gravityDirection;

        // Limit the speed of the ball
        if (ballRigidbody.velocity.magnitude > maxBallSpeed)
        {
            ballRigidbody.velocity = ballRigidbody.velocity.normalized * maxBallSpeed;
        }

        // Apply a force to the ball in the direction of the movement direction
        ballRigidbody.AddForce(ballMovementDirection * ballForce * Time.fixedDeltaTime, ForceMode.Impulse);

    }
}

