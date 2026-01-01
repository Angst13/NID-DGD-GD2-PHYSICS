using UnityEngine;

public class LeverLoseDetector : MonoBehaviour
{
    public string playerName;
    public GameOverUI gameOverUI;

    [Header("Upper Chain Detection")]
    public Collider2D[] upperChainColliders; // assign in Inspector

    bool lost = false;
    float startTime;

    void Awake()
    {
        startTime = Time.time;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (lost) return;
        if (Time.time - startTime < 1f) return;

        // Lever hits ground
        if (collision.collider.CompareTag("ground"))
        {
            TriggerLoss();
        }
    }

    // This is called by chain parts
    public void UpperChainHitGround()
    {
        if (lost) return;
        if (Time.time - startTime < 1f) return;

        TriggerLoss();
    }

    void TriggerLoss()
    {
        lost = true;

        string winner =
            playerName == "Player 1" ? "Player 2" : "Player 1";

        gameOverUI.ShowWinner(winner);
    }
}
