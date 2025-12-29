using UnityEngine;

public class p1 : MonoBehaviour
{
    private HingeJoint2D hinge;
    private JointMotor2D motor;

    public float motorSpeed = 150f;
    public float motorTorque = 1000f;

    void Awake()
    {
        hinge = GetComponent<HingeJoint2D>();
        motor = hinge.motor;
    }

    void FixedUpdate()
    {
        bool forward = Input.GetKey(KeyCode.A); // forward push
        bool backward = Input.GetKey(KeyCode.D); // backward push

        if (forward && !backward)
        {
            hinge.useMotor = true;
            motor.motorSpeed = motorSpeed;
        }
        else if (backward && !forward)
        {
            hinge.useMotor = true;
            motor.motorSpeed = -motorSpeed;
        }
        else
        {
            // RELEASE — let physics take over
            hinge.useMotor = false;
            return;
        }

        motor.maxMotorTorque = motorTorque;
        hinge.motor = motor;
    }
}