using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Archer : Ability
{
    public GameObject bulletPrefab;  // Prefab for the bullet
    public float bulletSpeed = 5f;   // Speed at which bullets will travel
    public float spreadAngle = 15f;  // Angle between each bullet

    public override void Activate()
    {
        // Find the player object (make sure the player has a "Player" tag)
        GameObject player = GameObject.FindWithTag("Player");

        if (player == null) return;

        // Call the function to shoot bullets in a spread
        ShootBullets(player);
    }

    void ShootBullets(GameObject player)
    {
        // Directions for the bullets (center, left, right)
        Vector2[] directions = new Vector2[3];

        // Middle bullet (straight forward in the player's facing direction)
        directions[0] = player.transform.right;

        // Left bullet (slightly rotated to the left)
        directions[1] = Quaternion.Euler(0, 0, spreadAngle) * player.transform.right;

        // Right bullet (slightly rotated to the right)
        directions[2] = Quaternion.Euler(0, 0, -spreadAngle) * player.transform.right;

        // Loop through the directions and spawn bullets
        foreach (var dir in directions)
        {
            // Instantiate the bullet at the player's position
            GameObject bullet = Instantiate(bulletPrefab, player.transform.position, Quaternion.identity);

            // Apply velocity to the bullet (make sure the bullet has a Rigidbody2D)
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = dir * bulletSpeed;
            }
        }
    }
}
