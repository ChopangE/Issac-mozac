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
        Managers.StatManager.RefreshData();
        //Managers.SceneManager.LoadScene(Define.SceneType.InGame);
        Managers.SceneManager.LoadScene(Define.SceneType.InGame, true);
    }
    
    [Binding]
    public void SelectMage(){
        Managers.StatManager.Classes = Define.Classes.Mage;
        Managers.StatManager.RefreshData();
        //Managers.SceneManager.LoadScene(Define.SceneType.InGame);
        Managers.SceneManager.LoadScene(Define.SceneType.InGame, true);

    }

    
}
