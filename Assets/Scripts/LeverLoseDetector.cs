using UnityEngine;

public class LeverLoseDetector : MonoBehaviour
{
    public string playerName;        // <-- MUST be public
    public GameOverUI gameOverUI;    // <-- MUST be public

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

        if (collision.collider.CompareTag("ground"))
        {
            lost = true;
            DeclareLoss();
        }
    }

    void DeclareLoss()
    {
        string winner =
            playerName == "Player 1" ? "Player 2" : "Player 1";

        gameOverUI.ShowWinner(winner);
    }
}
