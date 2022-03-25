using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableSpawner : MonoBehaviour
{
    [SerializeField] List<GameObject> collectableList = new List<GameObject>();
    [SerializeField] int poolSize = 10;

    List<ObjectPool> collectablePool = new List<ObjectPool>(1);

    private void Awake()
    {
        collectablePool = new List<ObjectPool>(collectableList.Count);
        //for (int i = 0; i < collectableList.Count; i++)
        //{
        //    Debug.Log(i);
        //    collectablePool[i] = new ObjectPool(collectableList[i], poolSize, this.transform);
        //}
        collectablePool[0] = new ObjectPool(collectableList[0], poolSize, this.transform);
    }

    public void SpawnCollectable(Vector3 _position)
    {
        var temp = collectablePool[0].NextFree();
        temp.transform.position = _position;
    }

    public void DespawnCollectable(GameObject _obj)
    {
        if (collectablePool[0].ObjectList.Contains(_obj))
        {
            _obj.SetActive(false);
        }
    }
}
