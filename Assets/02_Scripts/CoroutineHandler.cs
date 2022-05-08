using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineHandler : PersistentSingleton<CoroutineHandler>
{

    public void StartCoroutineOnInstance(string _name)
    {
        StartCoroutine(_name);
        
    }
    public void StartDestroyAfterLifetime(float _lifetime, GameObject _obj)
    {
        StartCoroutine(DestroyAfterLifetime(_lifetime, _obj));

    }


    public IEnumerator DestroyAfterLifetime(float _lifetime, GameObject _obj)
    {
        yield return new WaitForSeconds(_lifetime);
        _obj.SetActive(false);
    }
}
