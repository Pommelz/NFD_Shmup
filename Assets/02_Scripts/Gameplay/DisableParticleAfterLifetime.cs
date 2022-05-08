using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableParticleAfterLifetime : MonoBehaviour
{
    [SerializeField] private float lifetime;
    ParticleSystem particle;

    private void Awake()
    {
        particle = GetComponent<ParticleSystem>();
        lifetime = particle.main.duration;
    }

    private void OnEnable()
    {
        StartCoroutine(DestroyAfterLifetime());
    }

    public virtual IEnumerator DestroyAfterLifetime()
    {
        yield return new WaitForSeconds(lifetime);
        this.gameObject.SetActive(false);
    }
}
