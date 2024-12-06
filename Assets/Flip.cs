using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flip : MonoBehaviour
{
    public Transform player;
    public bool isFlip = false;

    Animator ab;
    EnemyStats enemyStats;

    private void Start()
    {
        ab = GetComponent<Animator>();
        enemyStats = GetComponent<EnemyStats>();
    }

    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if (transform.position.x > player.position.x && isFlip)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlip = false;
        }
        else if (transform.position.x < player.position.x && !isFlip)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180, 0f);
            isFlip = true;
        }
    }
}
