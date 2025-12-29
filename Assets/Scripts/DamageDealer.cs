using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    public float damageMultiplier = 0.05f;
    public float minImpulse = 2f;

    void OnCollisionEnter2D(Collision2D collision)
    {
        float impulse = collision.relativeVelocity.magnitude;
        if (impulse < minImpulse) return;

        DamageReciever dr =
            collision.collider.GetComponentInParent<DamageReciever>();

        if (dr)
        {
            float damage = Mathf.Min(
                impulse * impulse * damageMultiplier,
                40f
            );

            dr.ApplyDamage(damage);
        }
    }
}

