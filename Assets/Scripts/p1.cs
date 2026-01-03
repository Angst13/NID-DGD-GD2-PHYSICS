using UnityEngine;

public class p1 : MonoBehaviour
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

        if (Input.GetKey(KeyCode.A))
            velocity = targetVelocity;
        else if (Input.GetKey(KeyCode.D))
            velocity = -targetVelocity;

        if (Mathf.Abs(velocity) > 0f)
        {
            hinge.useMotor = true;
            motor.motorSpeed = velocity;      //  VELOCITY
            motor.maxMotorTorque = motorTorque;
            hinge.motor = motor;
        }
        else
        {
            // let physics take over
            hinge.useMotor = false;
        }
    }
}