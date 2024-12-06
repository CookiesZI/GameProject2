using UnityEngine;

[CreateAssetMenu(fileName = "WeaponEvolutionBlueprint", menuName ="ScriptableObject/WeaponEvolutionBlueprint")]
public class WeaponEvoBluePrints : ScriptableObject
{
    public WeaponScriptableObject baseWeaponData;
    public PassiveItemScriptable passiveItemData;
    public WeaponScriptableObject evolvedWeaponData;
    public GameObject evolvedWeapon;
}
