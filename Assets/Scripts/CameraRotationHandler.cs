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
        if(Input.GetMouseButton(0)){
            // Get the mouse delta. This is not in the range -1...1
            float h = horizontal_speed * Input.GetAxis("Mouse X");
            float v = vertical_speed * Input.GetAxis("Mouse Y");
            float zoom = zoom_speed * Input.mouseScrollDelta.y;

            Debug.Log(Input.mouseScrollDelta.y);


            // v is inversed because...reasons
            transform.RotateAround(origin, Vector3.up, h);
            transform.position = new Vector3(transform.position.x, transform.position.y - v, transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(origin.x, transform.position.y, origin.z), zoom);
        }
    }
}
