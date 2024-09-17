using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItem : MonoBehaviour, IItem
{
    Player.Player player;
    public float degree = 10.0f;

    void Start()
    {
        InGameScene inGameScene = Managers.SceneManager.CurrentScene as InGameScene;
        if (inGameScene == null) return;
        player = inGameScene.player;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void Use()
    {
        player.curHealth = Mathf.Min(player.curHealth + degree, player.maxHealth);
        Managers.ResourceManager.Destroy(gameObject);
    }

    
}
