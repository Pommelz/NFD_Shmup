using UnityEngine;
[RequireComponent(typeof(Health), (typeof(Collider)))]
public class BaseEnemy : MonoBehaviour
{
    CollectableSpawner collectableSpawn;
    [SerializeField] float movementSpeed = 2f;
    [Range(0, 100)] float probability = 30;
    public float Probaility { get => probability; set => probability = value; }

    private void Awake()
    {
        collectableSpawn = FindObjectOfType<CollectableSpawner>();
    }

    protected void OnDisable()
    {
        SpawnCollectable();
    }

    private void Update()
    {
        MoveToBottom();
    }

    protected void MoveToBottom()
    {
        transform.position += Vector3.down * Time.deltaTime * movementSpeed;
    }

    protected void SpawnCollectable()
    {
        float success = Random.Range(0, 100);
        if (success >= probability)
        {
            if (collectableSpawn)
            {
                collectableSpawn.SpawnCollectable(transform.position);
            }
        }
    }
}
