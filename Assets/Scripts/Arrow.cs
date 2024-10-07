using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public int damage = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Enemy enemyController = collision.GetComponent<Enemy>();
            if (enemyController != null)
            {
                enemyController.TakeDamage(damage);
            }

            Destroy(gameObject); // Destroy the projectile on impact
        }
    }

    private void Update()
    {
        // Optional: Destroy the projectile after a certain amount of time (to prevent infinite projectiles in the scene)
        Destroy(gameObject, 5f); // Adjust the lifetime if necessary
    }
}
