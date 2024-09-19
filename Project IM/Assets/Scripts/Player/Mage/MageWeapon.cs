using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageWeapon : PlayerWeapon
{
    private const float ShootPower = 5f;
    public override void StartAttack()
    {
        SpawnFire();
    }
    
    private void SpawnFire()
    {
        GameObject bullet = Managers.ResourceManager.InstantiatePrefab("Weapon/FireBall", gameObject.transform);
        if (bullet == null) return;
        FireBallBullet bb = bullet.GetComponent<FireBallBullet>();
        if (bb == null) return;
        bb.InitDamage(player.damage);
        bb.Init(playerControl as MageController);
        bullet.transform.position = player.transform.position;
        Vector3 dir = playerControl.direction.magnitude > 0 ? playerControl.direction : playerControl.prevDirection;
        bullet.transform.rotation = Quaternion.FromToRotation(Vector3.down,dir);
        bullet.GetComponent<Rigidbody2D>().AddForce(ShootPower * dir, ForceMode2D.Impulse);

    }
        
    
}
