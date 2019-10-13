using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    private readonly float limitPositionX = 10f; // Stores the screen limit in X axis.
    private readonly float limitPositionY = 10f; // Stores the screen limit in Y axis.

    void Update () { 
        // Making the camera follow the ship through keyboard inputs.
        Vector3 newPosition = new Vector3(0, 0, 0); // Receives the new position to the ship.

        // Checking keyboard inputs using 'if statement' to get the new position to the camera.
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            newPosition = new Vector3(-10, 0, 0) * Time.deltaTime;  // Changing the X position to make the camera move to the left and adding to newPosition.
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            newPosition = new Vector3(0, -10, 0) * Time.deltaTime; // Changing the Y position to make the camera move downward and adding to newPosition.
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            newPosition = new Vector3(0, 10, 0) * Time.deltaTime; // Changing the Y position to make the camera move upward and adding to newPosition.
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            newPosition = new Vector3(10, 0, 0) * Time.deltaTime; // Changing the X position to make the camera move to the right and adding to newPosition.
        }

        var newPositionLimit = gameObject.transform.position + newPosition; // Adding the new position to the camera and putting a variable.

        // Using if to check if the position don't exceed the limit,
        // Then the camera will move.
        if (newPositionLimit.x <= limitPositionX && newPositionLimit.x >= -limitPositionX // limit to the screen
            && newPositionLimit.y <= limitPositionY + 0.9f && newPositionLimit.y >= -limitPositionY + 0.9f)
        {
            transform.position += newPosition; // Changing camera position.
        }
    }
}
