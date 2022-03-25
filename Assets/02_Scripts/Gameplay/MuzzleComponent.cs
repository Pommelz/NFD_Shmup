using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzzleComponent : MonoBehaviour
{
    [SerializeField] ParticleSystem ps;


    private void Awake()
    {
        if (ps) return;
        ps = GetComponentInChildren<ParticleSystem>();
    }
    public void PlayVFX()
    {
        ps.Play();
    }
}
