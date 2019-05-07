using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour {

    public GameObject projectile;
    public float force_strength;
    private bool is_charging = false;
    public float charge_rate = 0.02f;
    private float total_charge = 0f;
    public float charge_max = 5f;

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


        //Debug.DrawLine(transform.position, transform.position + transform.forward.normalized * 10, Color.red, 2, false);
    }
	
    public void shoot(float power){
        GameObject new_p = Instantiate(projectile, transform.position, transform.rotation);
        Rigidbody rb = new_p.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward.normalized * power);
    }
}
