using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundFeedback : MonoBehaviour
{
    Shoot shootComponent;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Awake()
    {
        shootComponent = GetComponent<Shoot>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        shootComponent.Shoot_Event += OnShoot;   
    }

    private void OnDisable()
    {
        shootComponent.Shoot_Event -= OnShoot;
    }

    private void OnShoot()
    {
        if (!audioSource.isPlaying) audioSource.Play();
    }
}
