using UnityEngine;
using System.Collections;

public class DamageReciever : MonoBehaviour
{
    public float maxHealth = 100f;
    float currentHealth;
    bool broken = false;

    public AudioSource breakAudio; // 🔊 break sound

    void Awake()
    {
        currentHealth = maxHealth;

        // Auto-find AudioSource if not assigned
        if (breakAudio == null)
            breakAudio = GetComponent<AudioSource>();
    }

    public void ApplyDamage(float damage)
    {
        if (broken) return;

        currentHealth -= damage;
        Debug.Log($"{gameObject.name} HP: {currentHealth}");

        if (currentHealth <= 0f)
        {
            broken = true;
            StartCoroutine(BreakAllJoints());
        }
    }

    IEnumerator BreakAllJoints()
    {
        // wait until physics step ends
        yield return new WaitForFixedUpdate();

        // 🔊 PLAY BREAK SOUND
        if (breakAudio != null)
        {
            breakAudio.Play();
        }

        // break all joints
        FixedJoint2D[] joints = GetComponents<FixedJoint2D>();
        foreach (var j in joints)
        {
            Destroy(j);
        }

        // reduce explosive forces
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity *= 0.3f;
            rb.angularVelocity *= 0.3f;
        }
    }
}
