using UnityEngine;

public class BallHitSound : MonoBehaviour
{
    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip hitSound;   // Single sound

    [Header("Pitch")]
    public float minPitch = 0.9f;
    public float maxPitch = 1.1f;

    [Header("Volume")]
    public float minVolume = 0.3f;
    public float maxForce = 10f;

    void Start()
    {
        if (audioSource == null)
            audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (hitSound == null) return;

        audioSource.pitch = Random.Range(minPitch, maxPitch);

        float force = collision.relativeVelocity.magnitude;
        float volume = Mathf.Clamp01((force / maxForce) + minVolume);

        audioSource.PlayOneShot(hitSound, volume);
    }
}
