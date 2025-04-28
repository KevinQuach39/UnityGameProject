using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Transform target;
    public float speed;
    public float attackDistance = 2f;
    private Animator animator;
    private Enemy enemyHealth;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        animator = GetComponent<Animator>();
        enemyHealth = GetComponent<Enemy>();
    }
    void Update()
    {
        if (enemyHealth != null && enemyHealth.IsDead())
        {
            return;
        }
        float distance = Vector3.Distance(transform.position, target.position);
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        transform.LookAt(target);
        if (distance <= attackDistance)
        {
            animator.SetBool("isAttacking", true);
        }
        else
        {
            animator.SetBool("isAttacking", false);
        }
    }
}