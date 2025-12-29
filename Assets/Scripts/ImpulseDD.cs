using UnityEngine;

public class ImpulseDD : MonoBehaviour
{
    public float damageMultiplier = 1f;
    public float minImpactVelocity = 1f;

    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        ImpulseDR breakable =
            collision.collider.GetComponentInParent<ImpulseDR>();

        if (breakable == null)
            return;

        float impactVelocity = collision.relativeVelocity.magnitude;

        if (impactVelocity < minImpactVelocity)
            return;

        float impulse = rb.mass * impactVelocity;

        breakable.ApplyImpulseDamage(impulse * damageMultiplier);
    }
}
