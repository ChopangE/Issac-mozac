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
        //캐릭터 선택창에서 Managers.StatManager.Classes를 선택하고 넘어옴
        if (className == "None") className = Define.Classes.Mage.ToString();  //에러상황 처리
        Managers.ResourceManager.InstantiatePrefab("Player/" + className);
        player = FindObjectOfType<Player.Player>();
        playerControl = FindObjectOfType<PlayerControl>();
    }

    void Start()
    {
        Managers.UIManager.OpenPage<InGameViewModel>();
    }

    public override void Clear()
    {
        Managers.UIManager.CloseAllPages();
    }
}
