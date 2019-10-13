using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipScript : MonoBehaviour {

    #region Variables
    public GameObject explosion; // Receives the explosion prefab.
    private GameObject aExplosion; // Receives the copy of explosion prefab to manipulation.

    public GameObject bullet; // Receives the bullet prefab.
    private readonly float timeBulletDelay = 0.5f; // Holds bullet delay (0.5 seconds), to avoid shooting spam.
    private float nextBullet = 0; // Holds the time to the next bullet.

    public static int score = 0; // Receives the score.

    private readonly float limitPositionX = 10f; // Stores the screen limit in X axis.
    private readonly float limitPositionY = 10f; // Stores the screen limit in Y axis.
    #endregion

    void Start()
    {
        score = 0; // Resetting the score, because otherwise the score will be the same when the game restart.
    }

    void Update()
    {
        Vector3 newPosition = new Vector3(0, 0, 0); // Receives the new position to the ship.

        // Checking keyboard inputs using 'if statement' to get the new position to the ship.
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            newPosition = new Vector3(-10, 0, 0) * Time.deltaTime; // Changing the X position to make the ship move to the left and adding to newPosition. 
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            newPosition = new Vector3(0, -10, 0) * Time.deltaTime; // Changing the Y position to make the ship move downward and adding to newPosition. 
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            newPosition = new Vector3(0, 10, 0) * Time.deltaTime; // Changing the Y position to make the ship move upward and adding to newPosition. 
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            newPosition = new Vector3(10, 0, 0) * Time.deltaTime; // Changing the X position to make the ship move to the right and adding to newPosition. 
        }
        // Activating the bullets when the `Space Bar` is pressed and limiting the spam of bullets:
        if (Input.GetKey(KeyCode.Space) && Time.time >= nextBullet) // If the time for the nextBullet is less equals than the Time, then the bullet will be created.
        {
            Fire(); // Calling a function to create the bullet.
        }
        
        var newPositionLimit = gameObject.transform.position + newPosition; // Adding the new position to the ship and putting a variable.

        // Using `if statement` to check if the position don't exceed the limit,
        // Then the ship will move
        if (newPositionLimit.x <= limitPositionX && newPositionLimit.x >= -limitPositionX // Limit ship position.
            && newPositionLimit.y <= limitPositionY && newPositionLimit.y >= -limitPositionY)
        {
            gameObject.transform.position += newPosition;  // Changing the ship position.
        }
       
    }

    // Using a function to create a clone of the bullet.
    // Creating a function to describe the ship's action of firing a bullet.
    void Fire() 
    {
        nextBullet = Time.time + timeBulletDelay; // Getting the time to the next bullet.
        Instantiate(bullet, gameObject.transform.position, Quaternion.identity); // Creating a clone of the bullet prefab.
    }
    
    // Detecting collisions against the ship using an Unity function.
    private void OnCollisionEnter(Collision collision)
    {
        // Making sure that the collision object is an Asteroid using an `if statement`.
        if (collision.gameObject.name == "Asteroid_01_S(Clone)") // Detecting the collision between the Ship and Asteroid.
        {
            GameObject asteroid = GameObject.FindWithTag("Asteroid"); // Get Asteroid GameObject, to access the Asteroid List.

            if (asteroid != null) // In case that the Asteroid GameObject was found. 
            {
                AsteroidScript _asteroidScript = asteroid.GetComponent<AsteroidScript>(); // Get AsteroidScript by Asteroid GameObject.

                aExplosion = Instantiate(explosion, collision.gameObject.transform.position, Quaternion.identity); // Creating a clone of the explosion and place it in the collision position.
                
                _asteroidScript.asteroids.Remove(collision.gameObject); // Removing asteroid from the list to avoid Missing Reference Exception.
                Destroy(collision.gameObject); // Destroying the asteroid after the collision in the screen.
            }
            
            LoadSceneScript loadScene = new LoadSceneScript();  // Instantiating LoadSceneScript to change scenes.
            loadScene.ChangeScene(2); // Changing to EndScene after collision.
        }
    }
}
