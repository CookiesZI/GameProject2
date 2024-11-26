using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveItem : MonoBehaviour
{
    protected PlayerStats player;
    public PassiveItemScriptable passiveItemData;

    protected virtual void ApplyModifiler()
    {

    }
    
    void Start()
    {
        player = FindObjectOfType<PlayerStats>();
        ApplyModifiler();
    }
}
