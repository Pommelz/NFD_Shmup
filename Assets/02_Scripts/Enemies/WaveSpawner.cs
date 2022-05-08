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
    int enemyWaveCounter;
    [SerializeField] LevelVariables levelVariables;


    ObjectPool enemyPool;
    private bool hasBoss;

    private void Awake()
    {
        enemyHolder = transform.parent;
        enemyPool = new ObjectPool(enemyPrefab, 25, enemyHolder);
    }

    private void Start()
    {

        enemyWaveCounter = levelVariables.LevelData.WaveNumber;
        //StartSpawning();
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
    public void StartSpawning()
    {
        isLevelFinished = false;
        spawnRoutine = StartCoroutine(SpawnEnemies());
    }

    public void EndSpawning()
    {
        isLevelFinished = true;
    }

    public LineRenderer RandomizeSpawnPattern()
    {
        Random.InitState(System.DateTime.Now.Millisecond);
        int rngNumber = Random.Range(0, wavePatternList.Count);
        return wavePatternList[rngNumber];
    }


    IEnumerator SpawnEnemies()
    {
        while (!isLevelFinished)
        {
            for (int i = 0; i < enemyWaveCounter; i++)
            {
                Debug.Log(i);
                SpawnWave();
                yield return new WaitForSeconds(spawnDelay);
            }
            if (hasBoss)
            {
                GameStateHandler.SetState(GameStates.Boss);
            }
            //else
            //{
            //    yield return new WaitForSeconds(5f);
            //    GameStateHandler.SetState(GameStates.BackToMenu);

            //}
            yield return null;
        }
    }
}
