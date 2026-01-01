using UnityEngine;
using System.Collections;

public class TowerBallshake : MonoBehaviour
{
    public float pushForce = 5f;
    public float shakeAmount = 0.05f;
    public float shakeDuration = 0.1f;

    private Vector3 _startPos;

    void Awake() => _startPos = transform.localPosition;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            // 1. Push the ball back
            Rigidbody2D rb = collision.rigidbody; 
            if (rb != null)
            {
                // Pushes the ball away from the face it hit
                rb.AddForce(collision.contacts[0].normal * pushForce, ForceMode2D.Impulse);
            }

            // 2. Shake the block
            StopAllCoroutines();
            StartCoroutine(Shake());
        }
    }

    IEnumerator Shake()
    {
        float t = 0;
        while (t < shakeDuration)
        {
            transform.localPosition = _startPos + (Vector3)Random.insideUnitCircle * shakeAmount;
            t += Time.deltaTime;
            yield return null;
        }
        transform.localPosition = _startPos;
    }
}