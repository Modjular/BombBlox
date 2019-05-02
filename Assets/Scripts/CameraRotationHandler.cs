using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotationHandler : MonoBehaviour
{
    public Vector3 origin = Vector3.zero;
    public float vertical_speed = 2.0f;
    public float horizontal_speed = 2.0f;
    public float zoom_speed = 2.0f;

    void Update()
    {
        //Debug.Log(Input.mouseScrollDelta.y);
        if(Input.mouseScrollDelta.y != 0){

            // Calculate the zoom factor
            float zoom = zoom_speed * Input.mouseScrollDelta.y;
            Debug.Log("ZOOM: " + zoom);
            Debug.Log("DIST: " + Vector3.Distance(transform.position, new Vector3(origin.x, transform.position.y, origin.z)));
            
            // We precalc the distance, ask if we zoomed too far
            // We reset if we zoomed too far
            if(Vector3.Distance(transform.position, new Vector3(origin.x, transform.position.y, origin.z)) < 3.0f && zoom > 0){
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(origin.x, transform.position.y, origin.z), zoom);
            
            }
        }

        if(Input.GetMouseButton(0)) {

            // Get the mouse delta. This is not in the range -1...1
            float h = horizontal_speed * Input.GetAxis("Mouse X");
            float v = vertical_speed * Input.GetAxis("Mouse Y");

            // v is inversed because...reasons
            transform.RotateAround(origin, Vector3.up, h);
            transform.position = new Vector3(transform.position.x, transform.position.y - v, transform.position.z);

            if (transform.position.y < -0.5f){
                transform.position = new Vector3(transform.position.x, -0.5f, transform.position.z);
            }else if (transform.position.y > 10f){
                transform.position = new Vector3(transform.position.x, 10f, transform.position.z);
            }
        }

        if(movementKeysActivated()) {
            float h = -horizontal_speed * 0.25f * Input.GetAxis("Horizontal");
            float v = -vertical_speed * 0.25f * Input.GetAxis("Vertical");

            // v is inversed because...reasons
            transform.RotateAround(origin, Vector3.up, h);
            transform.position = new Vector3(transform.position.x, transform.position.y - v, transform.position.z);

            if (transform.position.y < -0.5f){
                transform.position = new Vector3(transform.position.x, -0.5f, transform.position.z);
            }else if (transform.position.y > 10f){
                transform.position = new Vector3(transform.position.x, 10f, transform.position.z);
            }
        }
    }

    bool movementKeysActivated() {
        if (Input.GetKey(KeyCode.W) ||
            Input.GetKey(KeyCode.A) ||
            Input.GetKey(KeyCode.S) ||
            Input.GetKey(KeyCode.D) ||
            Input.GetKey(KeyCode.UpArrow) ||
            Input.GetKey(KeyCode.LeftArrow) ||
            Input.GetKey(KeyCode.DownArrow) ||
            Input.GetKey(KeyCode.RightArrow)) {
                return true;
            }
        return false;
    }
}
