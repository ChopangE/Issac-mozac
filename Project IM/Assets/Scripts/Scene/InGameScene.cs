using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Util;

public class InGameScene : BaseScene
{
    public Player.Player player;
    public PlayerControl playerControl;
    protected override void Init()
    {
        base.Init();
        SceneType = Define.SceneType.InGame;
        player = FindObjectOfType<Player.Player>();
        playerControl = FindObjectOfType<PlayerControl>();
    }

    void Start()
    {
        Managers.UIManager.OpenPage<InGameViewModel>();
    }

    public override void Clear()
    { }
}
