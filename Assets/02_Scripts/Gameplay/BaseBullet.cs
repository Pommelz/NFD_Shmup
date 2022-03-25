using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        transform.position += _direction * speed;
    }

    public virtual IEnumerator DestroyAfterLifetime()
    {
        yield return new WaitForSeconds(lifetime);
        this.gameObject.SetActive(false);
        yield return null;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
        if (other.CompareTag(StringCollection.PLAYER))
        {
            CheckForHealthAndDropLife(other);
        }
        else if (other.CompareTag(StringCollection.ENEMY))
        {
            CheckForHealthAndDropLife(other);
        }
    }

    private void CheckForHealthAndDropLife(Collider other)
    {
        var health = other.GetComponent<Health>();
        if (health != null)
        {
            health.LoseLife();
        }
    }

}
