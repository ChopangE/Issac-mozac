using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItem : MonoBehaviour, IItem
{
    Player.Player player;
    private float degree = 10.0f;

    void Start()
    {
        InGameScene inGameScene = Managers.SceneManager.CurrentScene as InGameScene;
        if (inGameScene == null) return;
        player = inGameScene.player;
    }

    public void Use()
    {
        Debug.Log("Use!");
        player.curHealth = Mathf.Min(player.curHealth + degree, player.maxHealth);
        Managers.ResourceManager.Destroy(gameObject);
    }

    
}
