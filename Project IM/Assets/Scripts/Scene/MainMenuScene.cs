using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;

public class MainMenuScene : BaseScene
{

    protected override void Init()
    {
        base.Init();
        SceneType = Define.SceneType.MainMenu;
    }

    public override void Clear()
    {
    }
}
