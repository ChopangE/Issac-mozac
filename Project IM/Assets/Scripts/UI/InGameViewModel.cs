using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityWeld.Binding;
using Random = UnityEngine.Random;

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
    
    private float fHP;
    [Binding]
    public float FHP
    {
        get
        {
            return fHP; 
            
        }
        set
        {
            if (fHP == value) return;
            fHP = value;
            OnPropertyChanged("FHP");
        }
    }
    void Start()
    {
        Init();
    }

    void Init()
    {
        player = FindObjectOfType<Player.Player>();
        HP = player.curHealth.ToString();
        FHP = player.curHealth / Managers.StatManager.GetMaxHealth();
        MethodBinding();
    }
    void HpBinding(float value)
    {
        HP = value.ToString();
    }

    void FHpBinding(float value)
    {
        FHP = value / Managers.StatManager.GetMaxHealth();
    }
    
    void MethodBinding()                    //필요한 method들을 binding하는 method
    {
        player.healthEvent += HpBinding;
        player.healthEvent += FHpBinding;
    }

    private void OnDisable()
    {
        player.healthEvent -= HpBinding;
        player.healthEvent -= FHpBinding;

    }
    
    [Binding]
    public void CreateStage()
    {
        InGameScene inGame = Managers.SceneManager.CurrentScene as InGameScene;
        inGame.CreateStage();
    }
    [Binding]
    public void SpawnSlime()
    {
        //Managers.ResourceManager.InstantiatePrefab("Slime");
        Managers.ResourceManager.InstantiatePrefab("Enemy/Slime");
    }
    [Binding]
    public void SpawnSlimeInRandomPos()
    {
        //Managers.ResourceManager.InstantiatePrefab("Slime");
        GameObject go = Managers.ResourceManager.InstantiatePrefab("Enemy/Slime");

        Vector2Int randomPos = Managers.MapManager.SelectRandomFloorPositionInStage();
        go.transform.position = new Vector3(randomPos.x, randomPos.y, 0);
    }

    [Binding]
    public void SpawnSkeletonRandomPos()
    {
        GameObject go = Managers.ResourceManager.InstantiatePrefab("Enemy/Skeleton");
        Vector2Int randomPos = Managers.MapManager.SelectRandomFloorPositionInStage();
        go.transform.position = new Vector3(randomPos.x, randomPos.y, 0);
    }
}


