using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStateManager : MonoBehaviour
{
    // state 1 = win
    // state 2 = lose
    // state 0 = neither
    int state = 0;
    public GameObject gameOverPanel;
    public GameObject success_text;
    public GameObject failure_text;

    void Update()
    {
        // If we have lost, pause the time
        if(state == 2){
            failure();
        }else if(state == 1){
            success();
        }
    }

    public void success()
    {
        Time.timeScale = 0;
        success_text.SetActive(true);
        gameOverPanel.SetActive(true);
    }

    public void failure(){
        Time.timeScale = 0;
        failure_text.SetActive(true);
        gameOverPanel.SetActive(true);
    }
    public void setState(int new_state) {
        state = new_state;
        Debug.Log("NEW STATE: "  + new_state);
    }

    public int getState(){ return state;}

    /*
        What does it mean for the game to be "won" or "lost"?
        The problem is that, if we run out of projectiles, the 
        simulation might still be running, so we cannot simply
        ask if the player has used up their shots. 

        So, that being said, do we loop over all blocks, asking
        if any of them are still moving?

        bool sceneAtRest():
            foreach object in Scene:
                if object.velocity > threshold:
                    return false
            return true;
        
        And we would only call this once all our projectiles were
        not moving. Heck, we could even call it only like once
        a second. 

        That being said, what about the future? I guess we'll figure it
        out when we get there

     */

    // Returns true if all objects in scene are at "rest"
    // Rest is determined by some minimum velocity

    // EDIT: I put this in CANNON.CS for convenience haha
    // bool sceneAtRest()
    // {
    //     foreach (GameObject go in GameObject.FindGameObjectsWithTag("Block")){
    //         if(go.GetComponent<Rigidbody>().velocity.magnitude > 0.5f){
    //             return false;
    //         }
    //     }
    //     return true;
    // }


    // For the retry button
    
    public void restart(){
        SceneManager.LoadScene("Main");
        Time.timeScale = 1;
    }
} 
