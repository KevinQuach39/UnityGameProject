using UnityEngine;
using UnityEngine.UI;
public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;
    [SerializeField] private Text healthText;
    [SerializeField] private GameObject gameOverPanel;
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
}