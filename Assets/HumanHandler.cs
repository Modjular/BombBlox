using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanHandler : MonoBehaviour
{
    [SerializeField] GameStateManager gamestate;
    private Rigidbody rb;
    float velocity;
    bool is_dead;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        is_dead = false;
    }

    // Update is called once per frame
    void Update()
    {
        velocity = rb.velocity.magnitude;

        if(is_dead == true) {
            gamestate.setState(2);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(velocity);

        if(velocity >= 5) {
            is_dead = true;
        }

        Debug.Log(is_dead);
        
    }
}
