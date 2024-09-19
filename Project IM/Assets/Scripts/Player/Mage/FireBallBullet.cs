using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallBullet : ArrowBullet
{
    public MageController playerControl;
    
    public override void OnEnable()
    {
        base.OnEnable();
        
        //transform.localScale = Vector3.one * (playerControl.castingTimer/10.0f);
    }

    public void Init(MageController playerControl)
    {
        this.playerControl = playerControl;
    }

}
