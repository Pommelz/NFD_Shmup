using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var temp = other.GetComponent<Health>();
        if (!temp) return;
        CheckForHealthAndDropLife(temp);

    }

    private void CheckForHealthAndDropLife(Health health)
    {
        FindObjectOfType<VFXHandler>().OnHit(transform.position);
        health.LoseLife();
    }
}
