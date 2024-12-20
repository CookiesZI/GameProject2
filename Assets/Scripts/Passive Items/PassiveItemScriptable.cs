using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PassiveItemScriptableOBject", menuName ="ScriptableObject/Passive Item")]
public class PassiveItemScriptable : ScriptableObject
{

    [SerializeField]
    float multipler;
    public float Multiplier { get => multipler; private set => multipler = value;}
    [SerializeField]
    int level;
    public int Level { get => level; private set => level = value; }
    [SerializeField]
    GameObject nextLevelPrefab;
    [SerializeField]
    new string name;
    public string Name { get => name; private set => name = value; }
    [SerializeField]
    string description;
    public string Description { get => description; private set => description = value; }
    public GameObject NextLevelPrefab { get => nextLevelPrefab; private set => nextLevelPrefab = value; }
    [SerializeField]
    Sprite icon;
    public Sprite Icon { get => icon; private set => icon = value; }
}
