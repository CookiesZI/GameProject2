using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public float attackRange = 1.5f; // Range of the melee attack
    public int attackDamage = 1; // Damage dealt by the attack

    public void PerformAttack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, attackRange);

        foreach (Collider2D enemy in hitEnemies)
        {
            if (enemy.CompareTag("Enemy"))
            {
                Debug.Log("Hit enemy: " + enemy.name);
                Enemy enemyController = enemy.GetComponent<Enemy>();
                if (enemyController != null)
                {
                    enemyController.TakeDamage(attackDamage);
                }
            }
        }
    }

    // Visualize attack range in the scene view
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
