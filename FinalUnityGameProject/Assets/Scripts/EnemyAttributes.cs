using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 100f;
    private bool isDead = false;
    private Animator animator;
    [HideInInspector]
    public EnemySpawner spawner;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void TakeDamage(float amount)
    {
        if (isDead) return;
        health -= amount;
        print("Zombie Health: " + health);
        if (health <= 0f)
        {
            Die();
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