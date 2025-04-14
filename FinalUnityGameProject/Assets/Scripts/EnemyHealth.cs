using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 20f;
    public bool dead = false;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void TakeDamage(float amount)
    {
        if (dead) return;

        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }
    void Die()
    {
        dead = true;
        if (animator != null)
        {
            animator.SetBool("isDead", true);
        }
        Destroy(gameObject, 2f);
    }
    public bool IsDead()
    {
        return dead;
    }
}