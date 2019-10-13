using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

    #region Variables

    public GameObject explosion; // Receives the explosion prefab.
    private GameObject aExplosion; // Receives the copy of explosion prefab to manipulation.

    #endregion

    void Update () {
        transform.position += new Vector3(0, 0, 10) * Time.deltaTime; // Changing the Z position to move the bullet forward.
    }

    // Detecting collisions related to the bullet using an Unity function.
    private void OnCollisionEnter(Collision collision)
    {
        // Making sure that object collision is an Asteroid.
        if (collision.gameObject.name == "Asteroid_01_S(Clone)") // Detecting the collision between Asteroid and Bullet.
        {
            ShipScript.score++; // Add 1 to score.

            GameObject asteroid = GameObject.FindWithTag("Asteroid"); // Getting the Game Object with the tag "Asteroid".

            if (asteroid != null) // Checking if asteroid gameObject was found.
            {
                AsteroidScript _asteroidScript = asteroid.GetComponent<AsteroidScript>(); // Getting the asteroid script.

                aExplosion = Instantiate(explosion, collision.gameObject.transform.position, Quaternion.identity); // Creating an explosion and placing in collision position
                
                _asteroidScript.asteroids.Remove(collision.gameObject); // Removing asteroid from the list to avoid Missing Reference Exception.
                Destroy(collision.gameObject); // Destroying the asteroid from the screen.
                Destroy(gameObject); // Destroying the bullet.
            }
        }
    }
}
