using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cannon : MonoBehaviour {

    [SerializeField] GameStateManager gamestate;
    public GameObject projectile;
    public float force_strength;
    private bool is_charging = false;
    public float charge_rate = 0.02f;
    private float total_charge = 0f;
    public float charge_max = 5f;
    public float ammo_remaining = 10;

    public Text count_text;


    void Awake(){
        gamestate = GameObject.FindGameObjectWithTag("GameManager")
            .GetComponent<GameStateManager>();
        
        if(!gamestate){
            Debug.LogError("Cannon cannot find anything tagged 'GameManager' in the scene");
        }
    }



    void Update(){
        if(Input.GetKeyDown(KeyCode.Space)){
            is_charging = true;
        }
        if(Input.GetKeyUp(KeyCode.Space)){
            is_charging = false;
            shoot(force_strength * total_charge);
            total_charge = 0;
        }

        if(is_charging && total_charge < charge_max){
            total_charge += charge_rate;
            Debug.Log("Cannon Charge: " + total_charge);
        }


        // we can only say we've lost if we're out of ammo
        // AND
        // all blocks are at rest
        if(ammo_remaining <= 0 && gamestate.getState() != 2)
        {
            // this second function is more expensive
            // I don't want it running every update()
            // if it doesn't have to be
            if(sceneAtRest()){
                gamestate.setState(2);
            }
        }
        //Debug.DrawLine(transform.position, transform.position + transform.forward.normalized * 10, Color.red, 2, false);
    }
	
    public void shoot(float power){
        if(ammo_remaining > 0)
        {
            ammo_remaining--;
            
            GameObject new_p = Instantiate(projectile, transform.position, transform.rotation);
            Rigidbody rb = new_p.GetComponent<Rigidbody>();
            rb.AddForce(transform.forward.normalized * power);
        
            // Update GUI
            count_text.text = "x " + ammo_remaining;
        }


        if (ammo_remaining == 0) {
            Debug.Log("OUT OF AMMO");
        }
    }

     // Returns true if all objects in scene are at "rest"
    // Rest is determined by some minimum velocity
    bool sceneAtRest()
    {
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Block")){
            if(go.GetComponent<Rigidbody>().velocity.magnitude > 0.5f){
                return false;
            }
        }
        return true;
    }
}
