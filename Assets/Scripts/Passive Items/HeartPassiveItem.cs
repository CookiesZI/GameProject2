using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartPassiveItem : PassiveItem
{
    protected override void ApplyModifiler()
    {
        player.CurrentHealth *= 1 + passiveItemData.Multiplier / 100f;
    }
}
