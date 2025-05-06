using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;
    [SerializeField] private Text healthText; 
    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthText(); 
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
    }
    private void UpdateHealthText()
    {
        if (healthText != null)
        {
            healthText.text = "Player Heatlh: " + currentHealth.ToString("F0");
        }
    }
}
