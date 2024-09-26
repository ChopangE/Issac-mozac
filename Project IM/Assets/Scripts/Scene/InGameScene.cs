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
        string className = Managers.StatManager.Classes.ToString();
        if (className == "None") className = Define.Classes.Archer.ToString();
        Managers.ResourceManager.InstantiatePrefab("Player/" + className);
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
