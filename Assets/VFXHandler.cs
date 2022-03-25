using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXHandler : MonoBehaviour
{
    [SerializeField] GameObject hitParticle;
    [SerializeField] ObjectPool hitObjects;
    [SerializeField] int poolSize;

    private void Start()
    {
        Transform poolParent = this.transform;        //poolSize = poolParent.childCount;
        hitObjects = new ObjectPool(hitParticle, poolSize, poolParent);
    }

    public void OnHit(Vector3 hitLocation)
    {
        var nextObject = hitObjects.NextFree();
        nextObject.transform.position = hitLocation;
    }
}
