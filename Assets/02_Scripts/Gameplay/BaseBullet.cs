using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Collider))]
public abstract class BaseBullet : MonoBehaviour
{
    [SerializeField] Vector3 direction = Vector3.up;
    [SerializeField] private float speed;
    [SerializeField] private float lifetime;

    protected virtual void OnEnable()
    {
        StartCoroutine(DestroyAfterLifetime());
        //CoroutineHandler.Instance.StartDestroyAfterLifetime(lifetime, this.gameObject);

    }
    protected virtual void Update()
    {
        MoveTowardsDirection(direction);
    }

    public virtual void MoveTowardsDirection(Vector3 _direction)
    {
        transform.position += _direction.normalized * Time.deltaTime * speed;
    }

    public virtual IEnumerator DestroyAfterLifetime()
    {
        yield return new WaitForSeconds(lifetime);
        this.gameObject.SetActive(false);
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag(StringCollection.PLAYER))
    //    {
    //        CheckForHealthAndDropLife(other);
    //    }
    //    else if (other.CompareTag(StringCollection.ENEMY))
    //    {
    //        CheckForHealthAndDropLife(other);
    //    }
    //}

    //private void CheckForHealthAndDropLife(Collider other)
    //{
    //    var health = other.GetComponent<Health>();
    //    if (health != null)
    //    {
    //        health.LoseLife();
    //    }
    //}

}
