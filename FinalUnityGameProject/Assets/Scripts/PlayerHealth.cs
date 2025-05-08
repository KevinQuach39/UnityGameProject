using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;
    [SerializeField] private Text healthText;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private Text zombiesKilledText;
    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthText();
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        print("Player Health: " + currentHealth);
        UpdateHealthText();
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        print("Player Died");
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }
        if (zombiesKilledText != null && Score.Instance != null)
        {
            if(Score.Instance.GetKillCount() == 1)
            {
                zombiesKilledText.text = "Final Score: " + Score.Instance.GetKillCount() + " kill";
            }
            zombiesKilledText.text = "Final Score: " + Score.Instance.GetKillCount() + " kills";
        }
        PlayerController controller = GetComponent<PlayerController>();
        if (controller != null)
        {
            controller.enabled = false;
        }
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    private void UpdateHealthText()
    {
        if (healthText != null)
        {
            healthText.text = "Player Health: " + currentHealth.ToString("F0");
        }
    }
    public void RestartGame()
    {
        if (Score.Instance != null)
        {
            Score.Instance.ResetKills();
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
