using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : WeaponController
{
    AudioManager audioManager;

    protected override void Start()
    {
        base.Start();
    }

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    protected override void Attack()
    {
        base.Attack();
        GameObject spawnProjectile = Instantiate(weapondata.Prefab);
        spawnProjectile.transform.position = transform.position;
        audioManager.PlayerSFX(audioManager.projectileSFX);
        spawnProjectile.GetComponent<ArrowBehaviour>().DirectionChecker(pm.lastMove);
    }
}
