using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterScriptableObject", menuName = "ScriptableObject/Character")]
public class CharacterScriptableObject : ScriptableObject
{
    [SerializeField]
    GameObject startingWeapon;
    public GameObject StartingWeapon {  get => startingWeapon; private set => StartingWeapon = value; }
    [SerializeField]
    float maxHealth;
    public float MaxHealth { get => maxHealth; private set => MaxHealth = value; }
    [SerializeField]
    float recovery;
    public float Recovery { get => recovery; private set => recovery = value; }
    [SerializeField]
    float moveSpeed;
    public float MoveSpeed { get => moveSpeed;  private set => MoveSpeed = value; }
    [SerializeField]
    float might;
    public float Might { get => might; private set => Might = value; }
    [SerializeField]
    float projectileSpeed;
    public float ProjectileSpeed { get => projectileSpeed; private set => projectileSpeed = value; }
}
