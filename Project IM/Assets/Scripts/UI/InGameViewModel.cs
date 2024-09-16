using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityWeld.Binding;

[Binding]
public class InGameViewModel : BaseViewModel
{
    private Player.Player player;

    
    private string HP_;
    [Binding]
    public string HP
    {
        get { return HP_; }
        set
        {
            if (HP_ == value) return;
            HP_ = value;
            OnPropertyChanged("HP");
        }
    }
    void Start()
    {
        Init();
    }

    void Init()
    {
        player = FindObjectOfType<Player.Player>();
        MethodBinding();
    }
    void HpBinding(float value)
    {
        HP = value.ToString();
    }

    void MethodBinding()                    //필요한 method들을 binding하는 method
    {
        player.healthEvent += HpBinding;
    }
}


