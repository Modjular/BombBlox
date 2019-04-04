using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOnCollisionHandler : MonoBehaviour {

    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            Debug.DrawRay(contact.point, contact.normal, Color.blue);
        }
        if (collision.relativeVelocity.magnitude > 2)
            audioSource.Play();
    }
}
