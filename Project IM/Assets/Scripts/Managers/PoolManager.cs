using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime.Tasks.Unity.UnityGameObject;
using Interface;
using Photon.Pun;
using UnityEngine;
using Util;

public class PoolManager : IManager
{


    class Pool
    {
        public GameObject Original { get; private set; }
        public Transform Root { get; set; }
        
        Stack<Poolable> _poolStack = new Stack<Poolable>();

        public void Init(GameObject original, int count = 5)
        {
            Original = original;
            Root = new GameObject().transform;
            Root.name = original.name + "_Root";

            for (int i = 0; i < count; i++)
            {
                Push(Create());
            }
        }

        Poolable Create()
        {
            GameObject go = Object.Instantiate<GameObject>(Original);
            Debug.Log(Original.name);
            //GameObject go = PhotonNetwork.Instantiate(Original.name, Vector3.zero, Quaternion.identity);   //네트워크 버전
            go.name = Original.name;
            return go.GetComponent<Poolable>();
        }
        
        public void Push(Poolable poolable)
        {
            if (poolable == null) return;
            poolable.transform.parent = Root;
            poolable.gameObject.SetActive(false);
            poolable.isUsing = false;
            
            _poolStack.Push(poolable);
        }

        public Poolable Pop(Transform parent)
        {
            Poolable poolable;
            if (_poolStack.Count > 0)
            {
                poolable = _poolStack.Pop();
            }
            else
            {
                poolable = Create();
            }
            poolable.gameObject.SetActive(true);
            poolable.transform.parent = parent;
            poolable.isUsing = true;
            return poolable;
        }
    }
    
    Dictionary<string, Pool> pools = new Dictionary<string, Pool>();
    
    Transform _rootEnemy;
    Transform _rootWeapon;

    public void Init()
    {
        if(_rootEnemy == null)
        {
            _rootEnemy = new GameObject("@Pools_EnemyRoot").transform;
            Object.DontDestroyOnLoad(_rootEnemy);
        }
        if(_rootWeapon == null)
        {
            _rootWeapon = new GameObject("@Pools_WeaponRoot").transform;
            Object.DontDestroyOnLoad(_rootWeapon);
        }
    }

    public void CreatePool(GameObject original, int count)
    {
        Pool pool = new Pool();
        pool.Init(original, count);
        Poolable poolable = original.GetComponent<Poolable>();
        if (poolable != null)
        {
            if (poolable.prefabType == Define.PrefabType.Weapon)
            {
                pool.Root.parent = _rootWeapon;
            }
            else if (poolable.prefabType == Define.PrefabType.Enemy)
            {
                pool.Root.parent = _rootEnemy;

            }
        }
        pools.Add(original.name, pool);
    }
    public void Push(Poolable poolable)
    {
        string name = poolable.gameObject.name;
        if (pools.ContainsKey(name) == false)
        {
            GameObject.Destroy(poolable.gameObject);
            return;
        }
        pools[name].Push(poolable);
    }
    
    public Poolable Pop(GameObject original, Transform parent = null)
    {
        if (pools.ContainsKey(original.name) == false)
        {
            CreatePool(original,5);
        }
        return pools[original.name].Pop(parent);
    }

    public GameObject GetOriginal(string name)
    {
        if(pools.ContainsKey(name) == false)
        {
            return null;
        }
        return pools[name].Original;
    }

    public void Clear()
    {
        foreach(Transform child in _rootEnemy) GameObject.Destroy(child.gameObject);
        foreach(Transform child in _rootWeapon) GameObject.Destroy(child.gameObject);
        
        pools.Clear();

    }
}
