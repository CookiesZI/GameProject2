using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpPick : PickUp
{
    public int experienceGranted;

    public override void Collect()
    {
        if (hasbeenCollected)
        {
            return;
        }
        else
        {
            base.Collect();
        }

        PlayerStats player = FindObjectOfType<PlayerStats>();
        player.IncreaseExperience(experienceGranted);
    }
}
