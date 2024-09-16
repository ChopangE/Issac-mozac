using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArchorWeapon : PlayerWeapon
{
    public override void StartAttack()
    {
        SpawnArrow();
    }

    void SpawnArrow()
    {
        Managers.ResourceManager.InstantiatePrefab("Weapon/Arrow", gameObject.transform);
        
    }
    
}
