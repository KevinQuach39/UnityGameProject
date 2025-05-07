using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float health = 100f;
    private bool isDead = false;
    private Animator animator;
    [HideInInspector] public EnemySpawner spawner;
    public GameObject healthUIPrefab;  
    private GameObject healthUIInstance;
    private Text healthText;
    private void Start()
    {
        animator = GetComponent<Animator>();
        if (healthUIPrefab)
        {
            healthUIInstance = Instantiate(healthUIPrefab);
            healthUIInstance.transform.SetParent(transform);  
            healthText = healthUIInstance.GetComponentInChildren<Text>();  
        }
        UpdateHealthText();
    }
    private void Update()
    {
        if (healthUIInstance != null)
        {
            Vector3 offsetPosition = transform.position + Vector3.up * 2f;
            healthUIInstance.transform.position = offsetPosition;
            healthUIInstance.transform.rotation = Quaternion.LookRotation(healthUIInstance.transform.position - Camera.main.transform.position);
        }
    }
    public void TakeDamage(float amount)
    {
        if (isDead) return;
        health -= amount;
        print("Zombie Health: " + health);
        UpdateHealthText();
        if (health <= 0f)
        {
            Die();
        }
    }
    private void UpdateHealthText()
    {
        if (healthText != null)
        {
            healthText.text = health.ToString("F0");  
        }
    }
    private void Die()
    {
        isDead = true;
        animator.SetBool("isDead", true);
        if (spawner != null)
        {
            spawner.EnemyDied();
        }
        if (Score.Instance != null)
        {
            Score.Instance.AddKill();
        }
        if (healthUIInstance != null)
        {
            Destroy(healthUIInstance);
        }
        StartCoroutine(DestroyAfterDeath());
    }
    private IEnumerator DestroyAfterDeath()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);  
    }
    public bool IsDead()
    {
        return isDead;
    }
}