using UnityEngine;

[CreateAssetMenu(fileName = "WeaponEvolutionBlueprint", menuName ="ScriptableObject/WeaponEvolutionBlueprint")]
public class WeaponEvoBluePrints : ScriptableObject
{
    public WeaponScriptableObject baseWeaponData;
    public WeaponScriptableObject secondBaseWeaponData;
    public WeaponScriptableObject evolvedWeaponData;
    public GameObject evolvedWeapon;
}
