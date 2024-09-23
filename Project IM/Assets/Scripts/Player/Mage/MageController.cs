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
            if (castingTimer >= MaxChargingTime)        //성공적
            {
                currentFireBallRadius = castingTimer;
                CastingEnd();
                GoAttack();
            }
        }
        
        if (Input.GetKeyDown(KeyCode.Z) && !isAttack )
        {
            isAttack = true;
            isCasting = true;
            rb.velocity = Vector2.zero;
        }
        else if (Input.GetKeyUp(KeyCode.Z) && isCasting )       //성공적
        {
            currentFireBallRadius = castingTimer;
            CastingEnd();
            GoAttack();
        }
    }
    
    public void CastingEnd()
    {
        anim.speed = player.atkSpeed;
        isCasting = false;
        castingTimer = 0f;
    }
    private void AnimStop()
    {
        anim.speed = 0.0f;
        isCasting = true;
    }

    private void GoAttack()
    {
        playerWeapon.StartAttacking(currentFireBallRadius);
        currentFireBallRadius = 0;
    }
}

    

