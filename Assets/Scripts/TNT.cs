using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TNT : MonoBehaviour {

    public float radius = 5.0F;
    public float power = 10.0F;
    public CameraShakeHandler csh;

    void OnCollisionEnter(Collision collision){
        if(collision.gameObject.tag == "Projectile"){
            //print("HIT BY PROJECTILE");
            Color faded = GetComponent<MeshRenderer>().material.color;
            faded.a = 0;
            //GetComponent<MeshRenderer>().material.color = faded;
            Material mymat = GetComponent<Renderer>().material;
            //mymat.SetColor("_EmissionColor", Color.white);
            explode();
        }
    }

    public void explode()
    {
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null)
                rb.AddExplosionForce(power, explosionPos, radius, 3.0F);
        }

        // Play the explosion sound and animations
        ParticleSystem ps = GetComponent<ParticleSystem>();
        GetComponent<AudioSource>().Play();
        ps.Play();

        // Begin Camera Shake and the "blowing up" animation
        StartCoroutine(csh.shakeCamera(1f, 0.4f));
        StartCoroutine(blowUp(GetComponent<AudioSource>().clip.length));
    }


    // Flashes white and blows up
    IEnumerator blowUp(float delay){

        Renderer r = GetComponent<MeshRenderer>();
        float t_scale = 5;
        float o = transform.localScale.x;

/*
        for (float t = 0; t < 1; t += 1/t_scale) 
        {
            r.material.SetColor("_EmissionColor", new Color(t,t,t));
            Debug.Log("EMISSION: " + r.material.GetColor("_EmissionColor"));
            transform.localScale = new Vector3(t+o,t+o,t+o);
            yield return new WaitForSeconds(delay/t_scale);
        }
*/

/*
So, a note about _EmissionColor.
Basically, I would enable it on my material, but leave it at #000000
However, probably as an optimization, Unity wouldn't initialize the _EmissionColor
and the emission color couldn't be changed. However, if I changed the emission
to something like #000001, it WOULD be recognized, and everything worked fine.

I wish they mentioned this in the docs.
*/
        r.material.SetColor("_EmissionColor", new Color(0.5f,0.5f,0.5f));
        transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        
        yield return new WaitForSeconds(0.1f);
        
        r.material.SetColor("_EmissionColor", new Color(0.9f,0.9f,0.9f));
        transform.localScale = new Vector3(2f, 2f, 2f);
        
        yield return new WaitForSeconds(0.1f);   

        r.enabled = false;
        Destroy(gameObject, delay);
    }
}
