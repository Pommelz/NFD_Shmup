using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] LineRenderer spawnPointObject;
    [SerializeField] List<LineRenderer> wavePatternList;
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] float spawnDelay = 10f;
    Transform enemyHolder;
    Coroutine spawnRoutine;
    bool isLevelFinished = false;

    ObjectPool enemyPool;
    private void Awake()
    {
        enemyHolder = transform.parent;
        Debug.Log(enemyHolder.name + " " + enemyPrefab.name);
        enemyPool = new ObjectPool(enemyPrefab, 25, enemyHolder);
        Debug.Log(enemyPool.ObjectList.Count);

    }

    private void Start()
    {
        spawnRoutine = StartCoroutine(SpawnEnemies());
    }

    void SpawnWave()
    {
        LineRenderer nextWave = RandomizeSpawnPattern();
        for (int i = 0; i < nextWave.positionCount; i++)
        {
            //GameObject.Instantiate(enemyPrefab, nextWave.GetPosition(i), Quaternion.identity, enemyHolder);
            GameObject temp = enemyPool.NextFree();
            temp.transform.position = nextWave.GetPosition(i);
            temp.transform.rotation = Quaternion.identity;
        }
    }

    public void EndSpawning()
    {
        isLevelFinished = false;
    }

    public LineRenderer RandomizeSpawnPattern()
    {
        Random.InitState(System.DateTime.Now.Millisecond);
        int rngNumber = Random.Range(0, wavePatternList.Count);
        Debug.Log("Lucky number: " + rngNumber);
        return wavePatternList[rngNumber];
    }


    IEnumerator SpawnEnemies()
    {
        while (!isLevelFinished)
        {
            SpawnWave();
            yield return new WaitForSeconds(spawnDelay);
        }
        yield return null;
    }
}
