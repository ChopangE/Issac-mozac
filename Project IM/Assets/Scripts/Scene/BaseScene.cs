using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;

public abstract class BaseScene : MonoBehaviour
{
    public Define.SceneType SceneType { get; protected set; } = Define.SceneType.UnKnown;

    private void Awake()
    {
        Init();
    }

    protected virtual void Init()
    {
        
    }

    public abstract void Clear();
}
