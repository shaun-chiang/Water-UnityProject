using UnityEngine;
using System.Collections;

public class CamShakeSimple : MonoBehaviour
{

    Vector3 originalCameraPosition;

    float shakeAmt = 0;
    

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.tag.Equals("Enemy")) {
           shakeAmt = coll.relativeVelocity.magnitude * .0025f;
           InvokeRepeating("CameraShake", 0, .01f);
           Invoke("StopShaking", 0.3f);
    }

    }

    void CameraShake()
    {
        if (shakeAmt > 0)
        {
            float quakeAmt = Random.value * shakeAmt * 10 - shakeAmt;
            Vector3 pp = Camera.main.transform.position;

            pp.x += quakeAmt; // can also add to x and/or z
            pp.y += quakeAmt; // can also add to x and/or z
            pp.z += quakeAmt; // can also add to x and/or z
            Camera.main.transform.position = pp;
        }
    }

    void StopShaking()
    {
        CancelInvoke("CameraShake");
        Camera.main.transform.position = originalCameraPosition;
    }

}
