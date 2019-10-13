using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScript : MonoBehaviour {

    #region Variables
    public GameObject asteroid; // Receives the Asteroid prefab.
    private GameObject aAsteroid; // Receives the copy of asteroid prefab to manipulation.

    private readonly float limitScreenAsteroid = -50; // Holds the screen limit to the Asteroid in Z Axis.

    public List<GameObject> asteroids = new List<GameObject>(); // Instantiating a list of GameObjects.
    private readonly float asteroidDelay = 0.1f; // Holds bullet delay (0.5 seconds), to avoid asteroid spam.
    private float nextAsteroid = 0;  // Holds the time to the next Asteroid.
    #endregion

    // Update is called once per frame
    void Update()
    {
        // Limiting spam of Asteroid:
        if (Time.time >= nextAsteroid) // If the time for the nextAsteroid is less equals than the Time, then the asteroid will be created.
        {
            AsteroidGenerator(); // Using a function to create a new asteroid.
        }

        foreach (var a in asteroids) // Using a foreach to change the position of each asteroid in the list.
        {
            a.transform.position -= new Vector3(0, 0, 10) * Time.deltaTime; // Changing the asteroids positions, changing the Z Axis position.
        }

        CleanScreen(); // Using a function to remove the asteroids from the screen.

    }

    // Using a function to create a clone of the asteroid.
    // Creating a function to separete the code related to the asteroid generator of the asteroid update function.  
    public void AsteroidGenerator()
    {
        nextAsteroid = Time.time + asteroidDelay;  // Getting the time to the next asteroid.

        // Using the Random.Range to get random positions to X Axis and Y Axis with numbers between -10 and 10
        var yPosition = Random.Range(-10, 10);
        var xPosition = Random.Range(-12, 12);

        aAsteroid = Instantiate(asteroid, new Vector3(xPosition, yPosition, 20), Quaternion.identity); // Creating a clone from asteroid and placing in the screen in a random position.

        // Adding some properties to the new asteroid.
        aAsteroid.AddComponent<MeshCollider>(); // Adding Mesh Collider to increase collision detection accuracy.
        aAsteroid.GetComponent<MeshCollider>().convex = true; // Enables Mesh Collider to collide with other Mesh Colliders.
        aAsteroid.AddComponent<Rigidbody>(); // Adding a RigidBody to the Asteroid and to make the collision work.
        aAsteroid.GetComponent<Rigidbody>().useGravity = false; // Removing the gravity.
        aAsteroid.transform.localScale = new Vector3(4f, 4f, 4f); // Changing the object scale.

        asteroids.Add(aAsteroid); // Adding the new asteroid in the list.        
    }

    // Using a function to remove the asteroids that exceeded the screen limit from the screen.
    // Creating a function to separete the code related to the screen cleaning of the asteroid update function. 
    void CleanScreen()
    {
        for (var i = asteroids.Count - 1; i >= 0; i--) // Using `for` and starting by the last element to remove and don't affect the list index.
        {
            if (asteroids[i].transform.position.z <= limitScreenAsteroid) // Using `if statement` to check and to destroy the asteroids when they reach the screen limit.
            {
                Destroy(asteroids[i]); // Removing the asteroid from the screen.
                asteroids.Remove(asteroids[i]); // Removing the asteroid from the list.
            }
        }
    }
}
