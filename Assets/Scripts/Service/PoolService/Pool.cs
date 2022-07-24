using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

[Serializable]
public class Pool
{
    public GameObject Prefab;
    public int PrefabSize;

    private Queue<GameObject> prefabQueue;
    private Transform prefabParent;
    public int RunTimeSize => prefabQueue.Count;

    public void InitPool(Transform parent)
    {
        prefabQueue = new Queue<GameObject>();
        for (int i = 0; i < PrefabSize; i++)
        {
            prefabParent = parent;
            prefabQueue.Enqueue(Copy());
        }
    }

    private GameObject Copy()
    {
        GameObject go = Object.Instantiate(Prefab, prefabParent);
        go.SetActive(false);
        return go;
    }

    private GameObject GetAvailableGameObject()
    {
        GameObject available;
        if (prefabQueue.Count > 0 && prefabQueue.Peek().activeSelf == false)
        {
            available = prefabQueue.Dequeue();
        }
        else
        {
            available = Copy();
        }

        prefabQueue.Enqueue(available);
        return available;
    }

    public GameObject GetPrefab()
    {
        GameObject prefab = GetAvailableGameObject();
        prefab.SetActive(true);
        return prefab;
    }

    public GameObject GetPrefab(Vector3 position)
    {
        GameObject prefab = GetAvailableGameObject();
        prefab.transform.position = position;
        prefab.SetActive(true);
        return prefab;
    }

    public GameObject GetPrefab(Vector3 position, Quaternion rotation)
    {
        GameObject prefab = GetAvailableGameObject();
        prefab.transform.position = position;
        prefab.transform.rotation = rotation;
        prefab.SetActive(true);
        return prefab;
    }
}