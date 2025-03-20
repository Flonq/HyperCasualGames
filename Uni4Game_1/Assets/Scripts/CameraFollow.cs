using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed;
    public UnityEngine.Vector3 offset;

    // Update is called once per frame
    void LateUpdate()
    {
        UnityEngine.Vector3 desiredPosition = target.position + offset;
        UnityEngine.Vector3 smoothedPosition = UnityEngine.Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
