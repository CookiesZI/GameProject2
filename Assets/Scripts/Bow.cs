using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    public GameObject projectilePrefab; // Prefab of the projectile
    public Transform firePoint; // Position from where the projectile will be fired
    public float projectileSpeed = 10f; // Speed of the projectile
    public float attackCooldown = 1f; // Delay between attacks
    private float lastAttackTime;

    private void Start()
    {
        lastAttackTime = -attackCooldown; // Ensures the player can attack immediately when the game starts
    }

    public void PerformRangedAttack()
    {
        // Ensure the attack can only happen after the cooldown has passed
        if (Time.time >= lastAttackTime + attackCooldown)
        {
            FireProjectile();
            lastAttackTime = Time.time; // Reset the timer
        }
    }

    void FireProjectile()
    {
        // Instantiate the projectile at the fire point
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);

        // Add velocity to the projectile (it will move forward in the direction of firePoint's rotation)
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = firePoint.right * projectileSpeed; // Assuming firePoint points to the right (use local right direction
        }
    }
}
