using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagePlayer : Player.Player
{
    public override void GetDamage(float damage)
    {
        base.GetDamage(damage);
        if (playerControl as MageController != null)
        {
            MageController mageController = playerControl as MageController;
            mageController.CastingEnd();
        }
    }
}
