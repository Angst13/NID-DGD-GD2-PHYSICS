using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    public GameObject panel;
    public TMP_Text winnerText;

    void Awake()
    {
        panel.SetActive(false); // hide at start
    }

    public void ShowWinner(string winner)
    {
        panel.SetActive(true);
        winnerText.text = winner + " WINS!";
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
