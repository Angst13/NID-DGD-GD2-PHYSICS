using UnityEngine;

public class ForceLever : MonoBehaviour
{
    private HingeJoint2D hinge;
    private JointMotor2D motor;

    void Awake()
    {
        hinge = GetComponent<HingeJoint2D>();
        motor = hinge.motor;
        hinge.useMotor = true;
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.O))
        {
            motor.motorSpeed = 150f;
            motor.maxMotorTorque = 1000f;
        }
        else
        {
            motor.motorSpeed = 0f;
        }

        hinge.motor = motor;
    }
}