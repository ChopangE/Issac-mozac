using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageController : PlayerControl
{
    private bool isCasting = false;
    
    private const float MaxChargingTime = 3f;
    
    private float currentFireBallRadius;
    
    private float castingTimer = 0.0f;
    public override void AttackMethod()                 //PlayerControl의 Update문안에서 호출되는 함수
    {
        
        if (isCasting)
        {
            castingTimer += Time.deltaTime;
            if (castingTimer >= MaxChargingTime)
            {
                CastingEnd();
            }
        }
        
        if (!isCasting && anim.speed == 0)        //버그상황처리
        {
            CastingEnd();
        }
        
        if (Input.GetKeyDown(KeyCode.Z) && !isAttack )
        {
            isAttack = true;
            isCasting = true;
            rb.velocity = Vector2.zero;
        }
        
        if (Input.GetKeyUp(KeyCode.Z) && isCasting )
        {
            CastingEnd();
        }
    }

    private void CastingEnd()
    {
        currentFireBallRadius = castingTimer;
        anim.speed = player.atkSpeed;
        isCasting = false;
        castingTimer = 0f;
    }
    private void AnimStop()
    {
        anim.speed = 0.0f;
    }

    private void GoAttack()
    {
        playerWeapon.StartAttacking(currentFireBallRadius);
        currentFireBallRadius = 0;
    }
}

    

