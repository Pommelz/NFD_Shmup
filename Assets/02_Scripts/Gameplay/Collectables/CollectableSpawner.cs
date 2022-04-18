using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableSpawner : MonoBehaviour
{


    [SerializeField] GameObject collectable;
    [SerializeField] int poolSize = 40;

    [SerializeField] ObjectPool collectablePool;

    private void Awake()
    {
        //collectablePool = ObjectPool>(collectableList.Count);
        //for (int i = 0; i < collectableList.Count; i++)
        //{
        //    Debug.Log(i);
        //    collectablePool[i] = new ObjectPool(collectableList[i], poolSize, this.transform);
        //}
        collectablePool = new ObjectPool(collectable, poolSize, this.transform);
    }

    public void SpawnCollectable(Vector3 _position)
    {
        GameObject temp = collectablePool.NextFree();
        temp.SetActive(true);
        temp.transform.position = _position;
    }

    public void DespawnCollectable(GameObject _obj)
    {
        if (collectablePool.ObjectList.Contains(_obj))
        {
            _obj.SetActive(false);
        }
    }
}
