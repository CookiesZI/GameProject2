using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    //Current stats
    public float currentMoveSpeed;
    public float currentHealth;
    public float currentDamage;

    Transform player;

    [Header("Damage Feedback")]
    public Color damageColor = new Color(1, 0, 0, 1); // What the color of the damage flash should be.
    public float damageFlashDuration = 0.2f; // How long the flash should last.
    public float deathFadeTime = 0.6f; // How much time it takes for the enemy to fade.
    Color originalColor;
    SpriteRenderer sr;
    Enemy movement;

    public static int count; // Track the number of enemies on the screen.

    void Awake()
    {

        count++;
    }

    void Start()
    {
        player = FindObjectOfType<PlayerStats>().transform;
        sr = GetComponent<SpriteRenderer>();
        originalColor = sr.color;

        movement = GetComponent<Enemy>();
    }

    public void TakeDamage(float dmg, Vector2 sourcePosition, float knockbackForce = 5f, float knockbackDuration = 0.2f)
    {
        currentHealth -= dmg;
        StartCoroutine(DamageFlash());

        // Create the text popup when enemy takes damage.
        if (dmg > 0)
            GameManager.GenerateFloatingText(Mathf.FloorToInt(dmg).ToString(), transform);

        // Apply knockback if it is not zero.
        if (knockbackForce > 0)
        {
            // Gets the direction of knockback.
            Vector2 dir = (Vector2)transform.position - sourcePosition;
            movement.Knockback(dir.normalized * knockbackForce, knockbackDuration);
        }

        // Kills the enemy if the health drops below zero.
        if (currentHealth <= 0)
        {
            Kill();
        }
    }

    // This is a Coroutine function that makes the enemy flash when taking damage.
    IEnumerator DamageFlash()
    {
        sr.color = damageColor;
        yield return new WaitForSeconds(damageFlashDuration);
        sr.color = originalColor;
    }

    public void Kill()
    {
        DropRateManager drops = GetComponent<DropRateManager>();
        if (drops) drops.active = true;
        StartCoroutine(KillFade());
    }

    // This is a Coroutine function that fades the enemy away slowly.
    IEnumerator KillFade()
    {
        // Waits for a single frame.
        WaitForEndOfFrame w = new WaitForEndOfFrame();
        float t = 0, origAlpha = sr.color.a;

        // This is a loop that fires every frame.
        while (t < deathFadeTime)
        {
            yield return w;
            t += Time.deltaTime;

            // Set the colour for this frame.
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, (1 - t / deathFadeTime) * origAlpha);
        }

        Destroy(gameObject);
    }
    
    private void OnDestroy()
    {
        count--;
    }
}