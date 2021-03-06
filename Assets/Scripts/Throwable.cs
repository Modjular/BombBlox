﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Throwable is the base class for any throwable object.
// It handles gravity, colliding with blocks and block types

public class Throwable : MonoBehaviour {

    Collider col;
    public float floor = 0;
	
	void Update () {

        // This could also be tested by a collider, but this is just easier
        //Debug.Log(GetComponent<Rigidbody>().velocity.magnitude);
		if( transform.position.y < floor 
            //|| GetComponent<Rigidbody>().velocity.magnitude < 2f
        )
        {
            start_destroy();
        }
	}

    void start_destroy(){
        // Shrink, and then Destroy()
        // What happens when a coroutine is called every frame?
        StartCoroutine("shrink");
    }

    IEnumerator shrink(){
        for (float f = 1f; f >= 0.1; f -= 0.1f) 
        {
            transform.localScale = new Vector3(f,f,f);
            yield return null;
        }
        Destroy(gameObject);
    }
}
