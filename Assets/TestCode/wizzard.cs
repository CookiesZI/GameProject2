using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class wizzard : Ability
{
    public GameObject bulletPrefab;  // Prefab for the bullet
    public int bulletCount = 8;      // Number of bullets to shoot in a circle
    public float bulletSpeed = 5f;   // Speed at which bullets will travel
    public float bulletRadius = 1f;  // Distance from the player where bullets will spawn

    public override void Activate()
    {
        // Find the player object (make sure the player has a "Player" tag)
        GameObject player = GameObject.FindWithTag("Player");

        if (player == null) return;

        // Loop through and instantiate bullets in a circular pattern around the player
        for (int i = 0; i < bulletCount; i++)
        {
            // Calculate the angle for each bullet
            float angle = i * Mathf.PI * 2 / bulletCount;

            // Determine bullet spawn position
            Vector3 bulletPosition = new Vector3(
                player.transform.position.x + Mathf.Cos(angle) * bulletRadius,
                player.transform.position.y + Mathf.Sin(angle) * bulletRadius,
                0f
            );

            // Instantiate bullet at the calculated position
            GameObject bullet = Instantiate(bulletPrefab, bulletPosition, Quaternion.identity);

            // Get the direction for the bullet to move outward
            Vector2 moveDirection = (bullet.transform.position - player.transform.position).normalized;

            // Apply velocity to the bullet (make sure the bullet has a Rigidbody2D)
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = moveDirection * bulletSpeed;
            }
        }
    }
}
