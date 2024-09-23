using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageWeapon : PlayerWeapon
{
    private const float ShootPower = 5f;
    private const float PlusRatio = 1.5f;
   

    public override void StartAttacking(float radius = 0)
    {
        SpawnFire(radius);
    }
    
    private void SpawnFire(float radius)
    {
        GameObject bullet = Managers.ResourceManager.InstantiatePrefab("Weapon/FireBall", gameObject.transform);
        if (bullet == null) return;
        FireBallBullet bb = bullet.GetComponent<FireBallBullet>();
        if (bb == null) return;
        float upDegree = (1 + radius * PlusRatio / 3f);
        bb.InitDamage(player.damage * upDegree);
        bb.transform.localScale = Vector3.one * upDegree;
        bullet.transform.position = player.transform.position;
        Vector3 dir = playerControl.direction.magnitude > 0 ? playerControl.direction : playerControl.prevDirection;
        bullet.transform.rotation = Quaternion.FromToRotation(Vector3.down,dir);
        dir.Normalize();
        bullet.GetComponent<Rigidbody2D>().AddForce(ShootPower * dir, ForceMode2D.Impulse);

    }

    
        
    
}
