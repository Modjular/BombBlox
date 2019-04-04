using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShakeHandler : MonoBehaviour {

    public IEnumerator shakeCamera(float duration, float magnitude = 0.1f){

        float elapsed = 0.0f;
        Vector3 original_position = transform.localPosition;

        while(elapsed < duration){

            float t = elapsed / duration;

            float x = Random.Range(-1f, 1f) * magnitude * (1 - t);
            float y = Random.Range(-1f, 1f) * magnitude * (1 - t);

            transform.localPosition = new Vector3(x, y, original_position.z);

            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = original_position;
    }
}
