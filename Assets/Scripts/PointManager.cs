using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Keeps track of our points, will probably interface directly with the UI
// Maybe it would be better to have this in a central gameManager...
public class PointManager : MonoBehaviour
{
    public int points = 0;

    public void addPoints(int amt){
        points += amt;
        Debug.Log("Points added, total is now " + points);
    }
}
