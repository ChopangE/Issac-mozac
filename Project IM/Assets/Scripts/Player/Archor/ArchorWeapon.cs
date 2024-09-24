using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArchorWeapon : PlayerWeapon
{
    private const float ShootPower = 5f;
    public override void StartAttacking(float radius = 0)
    {
        SpawnArrow();
    }
    
    private void SpawnArrow()
    {
        GameObject bullet = Managers.ResourceManager.InstantiatePrefab("Weapon/Arrow", gameObject.transform);
        if (bullet == null) return;
        BulletBase bb = bullet.GetComponent<BulletBase>();
        if (bb == null) return;
        bb.InitDamage(player.damage);
        bullet.transform.position = player.transform.position;
        Vector3 dir = playerControl.direction.magnitude > 0 ? playerControl.direction : playerControl.prevDirection;
        bullet.transform.rotation = Quaternion.FromToRotation(Vector3.right,dir);
        dir.Normalize();
        bullet.GetComponent<Rigidbody2D>().AddForce(ShootPower * dir, ForceMode2D.Impulse);

    }
    
}
