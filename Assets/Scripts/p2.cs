using UnityEngine;

public class p2 : MonoBehaviour
{
    HingeJoint2D hinge;
    JointMotor2D motor;

    [Header("Angular Velocity Control")]
    public float targetVelocity = 30f;   // degrees per second
    public float motorTorque = 80f;      // strength to reach velocity

    void Awake()
    {
        hinge = GetComponent<HingeJoint2D>();
        motor = hinge.motor;
    }

    void FixedUpdate()
    {
        float velocity = 0f;

        if (Input.GetKey(KeyCode.J))
            velocity = targetVelocity;
        else if (Input.GetKey(KeyCode.L))
            velocity = -targetVelocity;

        if (Mathf.Abs(velocity) > 0f)
        {
            hinge.useMotor = true;
            motor.motorSpeed = velocity;      // 🎯 THIS IS VELOCITY
            motor.maxMotorTorque = motorTorque;
            hinge.motor = motor;
        }
        else
        {
            // Release — let physics take over
            hinge.useMotor = false;
        }
    }
}