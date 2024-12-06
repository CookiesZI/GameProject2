using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingBehaviour : ProjectileWeaponBehavior
{
    public string targetTag = "Enemy";
    private Transform target;
    protected override void Start()
    {
        base.Start();
        target = GameObject.FindGameObjectWithTag(targetTag)?.transform;
    }

    void Update()
    {
        if (target != null)
        {
            Vector3 directionToTarget = (target.position - transform.position).normalized;
            transform.position += directionToTarget * weaponData.Speed * Time.deltaTime;
        }
    }
}
