using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class SlimeAttack : AttackBT
{
    public override void OnStart() {
        anim.Play("SlimeAttack");
    }


    public override TaskStatus OnUpdate() {

    }
}
