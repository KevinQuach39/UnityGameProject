using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float damage = 10f;
    private void OnTriggerEnter(Collider other)
    {
        //print("On triggerenter works");
        if (other.CompareTag("Zombie"))
        {
            print("Zombie hit");
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
                Destroy(gameObject);
            }
        }
        else
        {
            //print("Collided with: " + other.gameObject.name);
        }
    }
}
