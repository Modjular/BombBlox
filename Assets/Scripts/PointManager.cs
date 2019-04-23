using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Keeps track of our points, will probably interface directly with the UI
// Maybe it would be better to have this in a central gameManager...
public class PointManager : MonoBehaviour
{
    public Text scoreText;

    public int points = 0;

    public void addPoints(int amt){
        points += amt;
        Debug.Log("Points added, total is now " + points);
    }
    
    void Update() {
        scoreText.text = "Score: " + points;
    }

}
