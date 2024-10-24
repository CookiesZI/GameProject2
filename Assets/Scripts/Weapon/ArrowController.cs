using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : WeaponController
{
    protected override void Start()
    {
        base.Start();
    }

    protected override void Attack()
    {
        base.Attack();
        GameObject spawnArrow = Instantiate(weapondata.Prefab);
        spawnArrow.transform.position = transform.position;
        spawnArrow.GetComponent<ArrowBehaviour>().DirectionChecker(pm.lastMove);
    }
}
