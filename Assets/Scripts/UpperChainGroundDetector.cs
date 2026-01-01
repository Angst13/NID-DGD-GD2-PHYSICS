using UnityEngine;

public class UpperChainGroundDetector : MonoBehaviour
{
    public LeverLoseDetector loseDetector;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("ground"))
        {
            loseDetector.UpperChainHitGround();
        }
    }
}
