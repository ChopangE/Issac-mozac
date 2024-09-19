using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArchorController : PlayerControl
{
    

    public override void AttackMethod()
    {
        if (Input.GetKeyDown(KeyCode.Z) && !isAttack)
        {
            isAttack = true;
            rb.velocity = Vector2.zero;
            playerWeapon.StartAttack();
            anim.speed = player.atkSpeed;
        }
    }
}
