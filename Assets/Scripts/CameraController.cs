using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;

    //public float distance = 10.0f; // Distance between the camera and the ball
    //public float height = 5.0f; // Height of the camera above the ball
    //public float smoothSpeed = 2.0f; // Smoothness of camera movement

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;

        //Vector3 targetPosition = player.transform.position + new Vector3(0, height, 0) - player.transform.forward * distance; // Calculate the target position for the camera
        //transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime); // Move the camera towards the target position
        //transform.LookAt(player.transform); // Rotate the camera to look at the ball
    }
}

