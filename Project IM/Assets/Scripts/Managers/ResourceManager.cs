using System.Collections;
using System.Collections.Generic;
using Interface;
using UnityEngine;

public class ResourceManager : IManager
{
    public T Load<T>(string path) where T : UnityEngine.Object
    {
        return Resources.Load<T>(path);
    }

    public GameObject InstantiatePrefab(string path, Transform parent = null)
    {
        GameObject prefab = Load<GameObject>("Prefabs/" + path);
        Debug.Log(path);
        //GameObject prefab = Load<GameObject>(path);
        if (prefab == null)
        {
            Debug.LogWarning("Prefab " + path + " could not be loaded");
            return null;
        }

        if (prefab.GetComponent<Poolable>() != null)
        {
            return Managers.PoolManager.Pop(prefab, parent).gameObject;
        }
        GameObject go = GameObject.Instantiate(prefab, parent);
        go.name = prefab.name;
        return go;
    }

    public void Destroy(GameObject go)
    {
        if (go == null) return;
        if (go.GetComponent<Poolable>() != null)
        {
            Managers.PoolManager.Push(go.GetComponent<Poolable>());
            return;
        }
        Object.Destroy(go);
    }

    public void Init()
    { }
}
