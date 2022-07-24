using System.Collections.Generic;
using UnityEngine;

public class PoolService : ServiceRoot<PoolService>
{
    public Transform PoolRoot;
    public Pool[] BulletPool;
    public Pool[] ExplodeEffectPool;
    public Pool[] ItemPool;
    public Pool[] ItemEffectPool;
    public Pool[] CubeEffectPool;
    public Pool[] DeathEffectPool;

    private readonly Dictionary<GameObject, Pool> poolDic = new Dictionary<GameObject, Pool>();

    public override void InitService()
    {
        base.InitService();
        InitPool(BulletPool);
        InitPool(ExplodeEffectPool);
        InitPool(ItemPool);
        InitPool(ItemEffectPool);
        InitPool(CubeEffectPool);
        InitPool(DeathEffectPool);
    }

    private void InitPool(IEnumerable<Pool> pools)
    {
        foreach (Pool pool in pools)
        {
            poolDic.Add(pool.Prefab, pool);
            Transform prefabParent = new GameObject("Pool" + pool.Prefab.name).transform;
            prefabParent.SetParent(PoolRoot);
            pool.InitPool(prefabParent);
        }
    }

    public GameObject GetPrefab(GameObject prefab)
    {
        return poolDic[prefab].GetPrefab();
    }

    public GameObject GetPrefab(GameObject prefab, Vector3 position)
    {
        return poolDic[prefab].GetPrefab(position);
    }

    public GameObject GetPrefab(GameObject prefab, Vector3 position, Quaternion rotation)
    {
        return poolDic[prefab].GetPrefab(position, rotation);
    }

    public void RecoveryAll()
    {
        for (int i = 0; i < PoolRoot.childCount; i++)
        {
            for (int j = 0; j < PoolRoot.GetChild(i).childCount; j++)
            {
                PoolRoot.GetChild(i).GetChild(j).gameObject.SetActive(false);
            }
        }
    }

#if UNITY_EDITOR

    private void CheckPoolSize(IEnumerable<Pool> pools)
    {
        foreach (Pool pool in pools)
        {
            if (pool.RunTimeSize > pool.PrefabSize)
            {
                Debug.LogWarning($"Pool:{pool.Prefab.name} " +
                                 $" has a runtime size {pool.RunTimeSize.ToString()}" +
                                 $" bigger than its initial size {pool.PrefabSize.ToString()}");
            }
        }
    }

    private void OnDestroy()
    {
        CheckPoolSize(BulletPool);
        CheckPoolSize(ExplodeEffectPool);
        CheckPoolSize(ItemPool);
        CheckPoolSize(ItemEffectPool);
        CheckPoolSize(CubeEffectPool);
        CheckPoolSize(DeathEffectPool);
    }

#endif
}