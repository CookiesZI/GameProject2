using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerRingPassiveItem : PassiveItem
{
    protected override void ApplyModifiler()
    {
        player.CurrentMagnet *= 1 + passiveItemData.Multiplier / 100f;
    }
}
