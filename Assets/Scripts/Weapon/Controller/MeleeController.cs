using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeController : WeaponController
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
        GameObject spawnMelee = Instantiate(weapondata.Prefab);
        spawnMelee.transform.position = transform.position;
        audioManager.PlayerSFX(audioManager.meleeSFX);
    }
}
