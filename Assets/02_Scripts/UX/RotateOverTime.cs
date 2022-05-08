using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateOverTime : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 5f;
    [SerializeField] Vector3 direction = Vector3.right;

    void Update()
    {
        transform.Rotate(direction * Time.deltaTime * rotationSpeed);
    }
}
