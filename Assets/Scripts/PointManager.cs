using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Keeps track of our points, will probably interface directly with the UI
// Maybe it would be better to have this in a central gameManager...
public class PointManager : MonoBehaviour
{
    public Text score_text;
    private AudioSource audio_source;

    public int points = 0;
    public int max_points = 250;
    GameStateManager gsm;

    void Start()
    {
        audio_source = GetComponent<AudioSource>();
        gsm = GameObject.FindGameObjectWithTag("GameManager")
            .GetComponent<GameStateManager>();
    }

    public void addPoints(int amt){
        points += amt;
        audio_source.Play();
    }
    
    void Update() {
        score_text.text = "X " + points + " / " + max_points;
        if(points >= max_points){
            gsm.setState(1);
        }
    }

}
