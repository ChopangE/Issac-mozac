using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityWeld.Binding;
using Util;

[Binding]
public class MainMenuViewModel : BaseViewModel
{
    
    [Binding]
    public void SelectArcher()
    {
        Managers.StatManager.Classes = Define.Classes.Archer;
        CallInGameScene();
        
    }
    
    [Binding]
    public void SelectMage(){
        Managers.StatManager.Classes = Define.Classes.Mage;
        CallInGameScene();
    }

    public void CallInGameScene()
    {
        Managers.SceneManager.LoadScene(Define.SceneType.InGame);

    }
}
