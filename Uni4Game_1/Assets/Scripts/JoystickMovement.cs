using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class JoystickMovement : MonoBehaviour
{
    public FloatingJoystick joystick;
    public float forwardMoveSpeed;
    public float horizontalMoveSpeed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UnityEngine.Vector3 direction = UnityEngine.Vector3.right * joystick.Horizontal + UnityEngine.Vector3.forward * forwardMoveSpeed;
        transform.position += horizontalMoveSpeed * direction * Time.deltaTime;

        UnityEngine.Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(transform.position.x, 4.3f, 13.3f);
        transform.position = pos;
    }
}
