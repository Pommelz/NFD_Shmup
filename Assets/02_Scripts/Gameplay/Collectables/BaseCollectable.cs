using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Collider), (typeof(AudioSource)))]
public abstract class BaseCollectable : MonoBehaviour
{
    [SerializeField] ParticleSystem ps;

    protected virtual void OnTriggerEnter(Collider other)
    {
        var temp = other.GetComponent<Health>();
        if (!temp) return;
        Disable();
    }

    public virtual void Disable()
    {
        //TODO: Play Particle & Sound
        this.gameObject.SetActive(false);
    }


}
