using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int score = 0;
    public int health = 3;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI healthText;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Update()
    {
        scoreText.text = "Score: " + score;
    }

    public void UpdateScore(int amount)
    {
        score += amount;
    }

    public void UpdateHealth(int amount)
    {
        health += amount;
        if (health > 3) health = 3;

        if (healthText != null)
            healthText.text = "Vies: " + health;

        if (health <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
