using UnityEngine;
using System.Collections;
public class Damagerecieverv2 : MonoBehaviour
{
    [Header("Health")]
    public float maxHealth = 100f;
    float currentHealth;
    bool dead = false;

    [Header("Player Info")]
    public string playerName;          // "Player 1" or "Player 2"
    public GameOverUI gameOverUI;       // drag Canvas here

    [Header("Health Bar")]
    public SpriteRenderer healthBar;

    float originalHeight;
    Vector3 originalLocalPos;

    void Start()
    {
        currentHealth = maxHealth;

        // Health bar setup
        if (healthBar != null)
        {
            originalHeight = healthBar.size.y;
            originalLocalPos = healthBar.transform.localPosition;
        }
    }

    public void ApplyDamage(float damage)
    {
        if (dead) return;

        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);

        UpdateHealthBar();

        // HP REACHED ZERO then GAME OVER
        if (currentHealth <= 0f)
        {
            dead = true;
            DeclareLoss();
        }
    }

    void UpdateHealthBar()
    {
        if (healthBar == null) return;

        float percent = currentHealth / maxHealth;

        Vector2 size = healthBar.size;
        size.y = originalHeight * percent;
        healthBar.size = size;

        float lost = originalHeight - size.y;
        Vector3 pos = originalLocalPos;
        pos.y = originalLocalPos.y - lost / 2f;
        healthBar.transform.localPosition = pos;
    }

    void DeclareLoss()
    {
        string winner =
            playerName == "Player 1" ? "Player 2" : "Player 1";

        gameOverUI.ShowWinner(winner);
    }
}