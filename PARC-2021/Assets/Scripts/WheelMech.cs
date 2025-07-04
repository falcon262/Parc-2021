﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelMech : MonoBehaviour
{
    public WheelCollider WC;
    public float torque = 200;
    public float maxSteerAngle = 30;
    public GameObject Wheel;
    // Start is called before the first frame update
    void Start()
    {
        WC = this.GetComponent<WheelCollider>();
    }

    void Go(float accel, float steer)
    {
        accel = Mathf.Clamp(accel, -1, 1);
        steer = Mathf.Clamp(steer, -1, 1) * maxSteerAngle;
        float thrustTorque = accel * torque;
        WC.motorTorque = -thrustTorque;
        WC.steerAngle = steer;

        Quaternion quat;
        Vector3 position;
        WC.GetWorldPose(out position, out quat);
        Wheel.transform.position = position;
        Quaternion localRot = Quaternion.Euler(0, 90, 0);
        Wheel.transform.rotation = quat * localRot;
    }

    // Update is called once per frame
    void Update()
    {
        float a = Input.GetAxis("Vertical");
        float s = Input.GetAxis("Horizontal");
        Go(a, s);
    }
}
