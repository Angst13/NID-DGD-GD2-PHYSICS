using UnityEngine;
using System.Collections;

public class DamageReciever : MonoBehaviour
{
    public float maxHealth = 100f;
    float currentHealth;
    bool broken = false;

    public AudioSource breakAudio;

    [Header("Damage Indicator")]
    public Transform damageIndicator;   // red child square
    float originalIndicatorHeight;

    void Awake()
    {
        currentHealth = maxHealth;

        if (breakAudio == null)
            breakAudio = GetComponent<AudioSource>();

        if (damageIndicator != null)
            originalIndicatorHeight = damageIndicator.localScale.y;
    }

    public void ApplyDamage(float damage)
    {
        if (broken) return;

        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);

        UpdateDamageIndicator();

        if (currentHealth <= 0f)
        {
            broken = true;
            StartCoroutine(BreakAllJoints());
        }
    }

    void UpdateDamageIndicator()
    {
        if (damageIndicator == null) return;

        float healthPercent = currentHealth / maxHealth;

        Vector3 scale = damageIndicator.localScale;
        scale.y = originalIndicatorHeight * healthPercent;
        damageIndicator.localScale = scale;
    }

    IEnumerator BreakAllJoints()
    {
        yield return new WaitForFixedUpdate();

        if (breakAudio != null)
            breakAudio.Play();

        FixedJoint2D[] joints = GetComponents<FixedJoint2D>();
        foreach (var j in joints)
            Destroy(j);

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity *= 0.3f;
            rb.angularVelocity *= 0.3f;
        }
    }
}
