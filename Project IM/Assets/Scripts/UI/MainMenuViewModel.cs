using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityWeld.Binding;
using Util;

[Binding]
public class MainMenuViewModel : BaseViewModel
{
    
    [Binding]
    public void SelectClass()
    {
        Managers.StatManager.Classes = Define.Classes.Archer;
        Managers.SceneManager.LoadScene(Define.SceneType.InGame);
    }
}
