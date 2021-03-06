﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// If this block falls below a certain point, it will be "collected"
// depending on its assigned point value
public class FailBlock : MonoBehaviour
{
    public int value = 10;
    public float ground = -0.9f;
    private Rigidbody rb;
    public UnityEvent failed_event;

    void Start(){
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Are we below the threshold
        // We could also test for velocity
        if(transform.position.y < ground && rb.velocity.magnitude < 0.1){
            //initiate point animation
            // then destroy the block
            StartCoroutine(animateThenDestroy());
        }
    }

    IEnumerator animateThenDestroy(){
        //wait a second
        yield return new WaitForSeconds(1.0f);
        //in a for loop, do some sort of destroy animation

        // Increment global "Points"

        //Destroy the object
        Debug.Log("Game over");
        failed_event.Invoke();
        Destroy(gameObject);
    }
}
