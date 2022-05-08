using UnityEngine;

public class MoveDown : MonoBehaviour
{
    [SerializeField] float movementSpeed = 10f;

    void Update()
    {
        transform.position += Vector3.down * movementSpeed * Time.deltaTime;
    }
}
