using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class SpinBehaviour : MeleeWeaponBehaviour
{
    public Transform pivot;
    private Vector3 initialPosition;

    protected override void Start()
    {
        base.Start();
        initialPosition = pivot.position;
    }

    void Update()
    {
        if (pivot != null)
        {
            // Rotate the object around the current position of the target on the Z-axis
            transform.RotateAround(pivot.position, Vector3.forward, weaponData.Speed * Time.deltaTime);
        }
    }
}
