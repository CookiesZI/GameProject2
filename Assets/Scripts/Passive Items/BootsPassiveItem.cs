using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BootsPassiveItem : PassiveItem
{
    protected override void ApplyModifiler()
    {
        player.currentMoveSpeed *= 1 + passiveItemData.Multiplier / 100f;
    }
}
