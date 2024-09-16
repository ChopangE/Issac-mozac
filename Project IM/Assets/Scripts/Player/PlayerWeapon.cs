using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class PlayerWeapon : MonoBehaviour
{
    protected Player.Player player;
    protected PlayerControl playerControl;
    public abstract void StartAttack();

    public virtual void Start()
    {
        player = GetComponent<Player.Player>();
        playerControl = GetComponent<PlayerControl>();
    }
}
