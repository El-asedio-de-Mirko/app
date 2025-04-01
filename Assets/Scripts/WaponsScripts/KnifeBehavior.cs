using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeBehavior : ProjectilWeapon
{
    protected override void Start()
    {
        base.Start();
    }

    
    void Update()
    {
        transform.position += direction * weaponData.Speed * Time.deltaTime;
    }
}
