using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallBullet : ArrowBullet
{
    
    public void OnDisable(){
        transform.localScale = Vector3.one;
    }
}
