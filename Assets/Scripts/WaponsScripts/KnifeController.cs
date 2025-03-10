using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeController : WeaponsController
{
    new KnifeController kc;
    protected override void Start()
    {
        base.Start();
    }

    protected override void Attack()
    {
        base.Attack();
        GameObject spawnedKnife = Instantiate(prefab);
        spawnedKnife.transform.position = transform.position;
        spawnedKnife.GetComponent<KnifeBehavior>().DirectionChecker(pm.moveDirection);
    }
}

