using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public static Action<Vector3> Hit_Event;

    [SerializeField] float lifetime;
    [SerializeField] float speed;
    [SerializeField] Vector3 direction = Vector3.up;

    // Update is called once per frame
    void Update()
    {
        MoveTowardsDirection(direction);   
    }

    private void OnEnable()
    {
        StartCoroutine("DestroyAfterLifetime");
    }

    public void MoveTowardsDirection(Vector3 _direction)
    {
        transform.position += _direction * speed;
    }

    public IEnumerator DestroyAfterLifetime()
    {
        yield return new WaitForSeconds(lifetime);
        this.gameObject.SetActive(false);
        yield return null;
    }
}
