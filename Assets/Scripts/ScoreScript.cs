using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour {
    
    public Text score; // Text that receive the value from the score.
	
	void Update () {
        score.text = ShipScript.score.ToString(); // getting the score value from the ShipScript and adding to the screen.
	}
}
