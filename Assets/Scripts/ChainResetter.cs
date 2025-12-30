using UnityEngine;
using System.Collections;

public class ChainResetter : MonoBehaviour
{
    public Rigidbody2D[] chainBodies;
    public float resetDelay = 5f;
    public float maxAllowedDistance = 1.5f;

    bool resetting = false;

    Vector2[] startPositions;
    float[] startRotations;

    void Awake()
    {
        int count = chainBodies.Length;
        startPositions = new Vector2[count];
        startRotations = new float[count];

        for (int i = 0; i < count; i++)
        {
            startPositions[i] = chainBodies[i].position;
            startRotations[i] = chainBodies[i].rotation;
        }
    }

    void FixedUpdate()
    {
        if (resetting) return;

        for (int i = 0; i < chainBodies.Length - 1; i++)
        {
            float dist = Vector2.Distance(
                chainBodies[i].position,
                chainBodies[i + 1].position
            );

            if (dist > maxAllowedDistance)
            {
                StartReset();
                break;
            }
        }
    }

    void StartReset()
    {
        if (!resetting)
            StartCoroutine(ResetChain());
    }

    IEnumerator ResetChain()
    {
        resetting = true;

        yield return new WaitForSeconds(resetDelay);

        for (int i = 0; i < chainBodies.Length; i++)
        {
            Rigidbody2D rb = chainBodies[i];

            rb.linearVelocity = Vector2.zero;
            rb.angularVelocity = 0f;

            rb.position = startPositions[i];
            rb.rotation = startRotations[i];
        }

        resetting = false;
    }
}
