using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableAfterLifetime : MonoBehaviour
{
    public float lifetime = 3f;

    private void OnEnable()
    {
        StartCoroutine(DestroyAfterLifetime());
    }
    // Start is called before the first frame update
    public virtual IEnumerator DestroyAfterLifetime()
    {
        yield return new WaitForSeconds(lifetime);
        this.gameObject.SetActive(false);
        yield return null;
    }
}
