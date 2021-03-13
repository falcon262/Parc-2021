using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    public WheelCollider WC1;
    public WheelCollider WC2;
    public WheelCollider WC3;
    public WheelCollider WC4;
    public GameObject Wheel1;
    public GameObject Wheel2;
    public GameObject Wheel3;
    public GameObject Wheel4;

    public float torque = 200;
    public float maxSteerAngle = 30;


    void Go(float accel, float steer)
    {
        accel = Mathf.Clamp(accel, -1, 1);
        steer = Mathf.Clamp(steer, -1, 1) * maxSteerAngle;
        float thrustTorque = accel * torque;
        WC1.motorTorque = -thrustTorque;
        WC2.motorTorque = -thrustTorque;
        WC3.motorTorque = -thrustTorque;
        WC4.motorTorque = -thrustTorque;
        WC1.steerAngle = steer;
        WC2.steerAngle = steer;

        Quaternion quat1;
        Quaternion quat2;
        Quaternion quat3;
        Quaternion quat4;
        Vector3 position1;
        Vector3 position2;
        Vector3 position3;
        Vector3 position4;
        WC1.GetWorldPose(out position1, out quat1);
        WC2.GetWorldPose(out position2, out quat2);
        WC3.GetWorldPose(out position3, out quat3);
        WC4.GetWorldPose(out position4, out quat4);
        Wheel1.transform.position = position1;
        Wheel2.transform.position = position2;
        Wheel3.transform.position = position3;
        Wheel4.transform.position = position4;
        Quaternion localRot = Quaternion.Euler(0, 90, 0);
        Wheel1.transform.rotation = quat1 * localRot;
        Wheel2.transform.rotation = quat2 * localRot;
        Wheel3.transform.rotation = quat3 * localRot;
        Wheel4.transform.rotation = quat4 * localRot;
    }

    void Update()
    {
        float a = Input.GetAxis("Vertical");
        float s = Input.GetAxis("Horizontal");
        Go(a, s);
    }
}
