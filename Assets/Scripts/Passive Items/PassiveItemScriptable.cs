using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PassiveItemScriptableOBject", menuName ="ScriptableObjects/Passive Item")]
public class PassiveItemScriptable : ScriptableObject
{

    [SerializeField]
    float multipler;
    public float Multiplier { get => multipler; private set => multipler = value;}

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
