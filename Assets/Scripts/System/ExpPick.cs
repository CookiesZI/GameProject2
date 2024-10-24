using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpPick : MonoBehaviour, ICollectible
{
    public int experienceGranted;

    public void Collect()
    {
        PlayerStats player = FindObjectOfType<PlayerStats>();
        player.IncreaseExperience(experienceGranted);
        Destroy(gameObject);
    }
}
