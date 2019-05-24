using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// If this block falls below a certain point, it will be "collected"
// depending on its assigned point value
public class PointBlock : MonoBehaviour
{
    PointManager pm;
    public int value = 10;
    public float ground = -0.9f;
    private Rigidbody rb;
    public UnityEvent earned_event;


    void Awake(){
        // We're doing this because it's too much work to 
        // manually connect the PointManager whenever we make a new scene
        // Theres probably a better way to do this.
        pm = GameObject.FindGameObjectWithTag("PointManager").
            GetComponent<PointManager>();

        if(!pm){
            Debug.LogError("PointBlock cannot find anything tagged 'PointManager' in the scene");
        }
    }


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
        //Debug.Log("Earned a point");
        //earned_event.Invoke();
        pm.addPoints(value);
        Destroy(gameObject);
    }
}
