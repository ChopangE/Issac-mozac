using System.Collections;
using System.Collections.Generic;
using Interface;
using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;
using Util;

public class SceneManager_ : IManager
{
    public BaseScene CurrentScene { get; private set; }

    // public SceneManager_()
    // {
    //     SceneManager.sceneLoaded += OnSceneLoaded;
    // }
    public void LoadScene(Define.SceneType type, bool isNetwork = false)
    {
        CurrentScene.Clear();
        if (isNetwork)
        {
            PhotonNetwork.LoadLevel(type.ToString());
        }
        else
        {
            SceneManager.LoadScene(type.ToString());
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        CurrentScene = GameObject.FindObjectOfType<BaseScene>();
    }

    public void Init()
    {
        CurrentScene = GameObject.FindObjectOfType<BaseScene>();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
}
