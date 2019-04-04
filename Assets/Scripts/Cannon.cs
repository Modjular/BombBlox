using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour {

    public GameObject projectile;
    public float force_strength;

    void Update(){
        if(Input.GetKeyDown(KeyCode.Space)){
            shoot();
        }
        Debug.DrawLine(transform.position, transform.position + transform.forward.normalized * 10, Color.red, 2, false);
    }
	
    public void shoot(){
        GameObject new_p = Instantiate(projectile, transform.position, transform.rotation);
        Rigidbody rb = new_p.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward.normalized * force_strength);
    }
}
