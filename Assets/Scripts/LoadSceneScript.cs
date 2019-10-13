using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneScript : MonoBehaviour {

    // A function to facility the changing to another scenes.
    public void ChangeScene(int changeTheScene) // Receives the number of the chosen scene.
    {
        SceneManager.LoadScene(changeTheScene); // Changing to the chosen scene.
    }
}
