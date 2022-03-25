using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    string sender = "";

    private void Awake()
    {
        sender = this.transform.parent.tag;
        this.tag = sender;
    }


    private void OnTriggerEnter(Collider other)
    {
        //if (other.gameObject.GetComponent<TouchTest>())
        //{
        //    CheckForHealthAndDropLife(other);
        //} else
         if (other.CompareTag(StringCollection.ENEMY))
        {
            CheckForHealthAndDropLife(other);
        }
    }

    private void CheckForHealthAndDropLife(Collider other)
    {
        var health = other.GetComponent<Health>();
        if (health != null)
        {
            FindObjectOfType<VFXHandler>().OnHit(transform.position);
            health.LoseLife();
        }
    }
}
