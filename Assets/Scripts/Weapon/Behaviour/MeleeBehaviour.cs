using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeBehaviour : MeleeWeaponBehaviour
{
    protected override void Start()
    {
        base.Start();
    }

    void Update()
    {
        transform.position += transform.forward * weaponData.Speed * Time.deltaTime;
    }

}
