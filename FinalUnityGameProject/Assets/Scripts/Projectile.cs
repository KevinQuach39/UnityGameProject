using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float damage = 10f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Zombie"))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
        else if (other.CompareTag("Spaceship"))
        {
            Spaceship spaceship = other.GetComponent<Spaceship>();
            if (spaceship != null)
            {
                GameObject player = GameObject.FindWithTag("Player");
                spaceship.OnHitByProjectile(player);
            }
            Destroy(gameObject);
        }
    }
}