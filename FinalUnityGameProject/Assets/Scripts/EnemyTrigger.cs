using UnityEngine;
public class EnemyTrigger : MonoBehaviour
{
    public float damageAmount = 10f;
    public float attackRate = 1f;
    private float nextAttackTime = 0f;
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth player = other.GetComponent<PlayerHealth>();
            Animator animator = GetComponent<Animator>();
            if (player != null && animator.GetBool("isAttacking"))
            {
                if (Time.time >= nextAttackTime)
                {
                    player.TakeDamage(damageAmount);
                    nextAttackTime = Time.time + attackRate;
                }
            }
        }
    }
}