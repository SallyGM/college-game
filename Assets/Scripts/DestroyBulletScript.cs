using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBulletScript : MonoBehaviour {

    public float delay; // Holds the delay for destroy the bullet.

	void Update () {
        Destroy(this.gameObject, delay); // Destroying the bullet with a delay
    }
}
