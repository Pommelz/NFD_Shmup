using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableAfterLifetime : MonoBehaviour
{
    public float lifetime = 3f;

    private void OnEnable()
    {
        StartCoroutine(DisableObjectAfterLifetime());
    }
    // Start is called before the first frame update
    public virtual IEnumerator DisableObjectAfterLifetime()
    {
        yield return new WaitForSeconds(lifetime);
        this.gameObject.SetActive(false);
    }
}
