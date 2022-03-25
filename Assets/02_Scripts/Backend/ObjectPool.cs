using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
[System.Serializable]
public class ObjectPool
{
    private List<GameObject> objectList;
    private GameObject go;
    private Transform parent;

    public List<GameObject> ObjectList { get => objectList; }

    public ObjectPool(GameObject ObjectToPool, int totalObjectsAtstart, Transform ParentObj)
    {
        objectList = new List<GameObject>(totalObjectsAtstart);
        go = ObjectToPool;
        for (int i = 0; i < totalObjectsAtstart; i++)
        {
            GameObject newObject = Object.Instantiate(go, ParentObj);
            newObject.transform.position = Vector3.zero;
            FreeObject(newObject);
            objectList.Add(newObject);
        }
    }
    public GameObject NextFree()
    {
        var freeObject = objectList.Where(x => x.activeSelf == false).FirstOrDefault();
        if (freeObject == null)
        {
            Debug.Log("object is null and get instantiated");
            freeObject = Object.Instantiate(go);
            objectList.Add(freeObject);
        }
        //freeObject.transform.parent = ParentObj;
        freeObject.SetActive(true);
        return freeObject;
    }
    public void FreeObject(GameObject objectToFree)
    {
        if (objectToFree != null)
        {
            objectToFree.SetActive(false);
        }
    }
}
