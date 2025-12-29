using UnityEngine;

public class ImpulseDR : MonoBehaviour
{
    public Joint2D joint;
    public float currentStrength;
    public float damageMultiplier = 1.6f;

    void Awake()
    {
        if (!joint)
            joint = GetComponent<Joint2D>();

        if (joint != null)
            currentStrength = joint.breakForce;
    }

    public void ApplyImpulseDamage(float impulse)
    {
        if (joint == null)
            return;

        float damage = impulse * damageMultiplier;
        currentStrength -= damage;

        joint.breakForce = currentStrength;

        if (currentStrength <= 0f)
            Destroy(joint);
    }
}
