using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShootingComponent : MonoBehaviour
{
    public Action Shoot_Event;

    [SerializeField] GameObject projectile;
    [SerializeField] bool hasMuzzle = true;
    [SerializeField] GameObject muzzleFlash;
    ObjectPool bulletPool;
    List<ObjectPool> muzzlePools = new List<ObjectPool>();
    [SerializeField] float weaponCooldown;
    [SerializeField] List<MuzzleComponent> weaponMuzzles;
    [SerializeField] int poolSize;
    private bool isBlocked = false;
    Transform poolParent;

    private void Awake()
    {
        poolParent = GameObject.Find(StringCollection.POOLPARENT).transform;
        bulletPool = new ObjectPool(projectile, poolSize, poolParent);
        if (hasMuzzle)
            weaponMuzzles = this.GetComponentsInChildren<MuzzleComponent>().ToList();
    }

    private void BlockShooting()
    {
        isBlocked = true;
    }

    private void UnblockShooting()
    {
        isBlocked = false;
        StartCoroutine(StartShooting());

    }

    private void OnEnable()
    {
        GameStateHandler.StateChanged_Event += OnStateChanged;
    }
    private void OnDisable()
    {
        GameStateHandler.StateChanged_Event -= OnStateChanged;
    }

    private void OnStateChanged(GameStates obj)
    {
        switch (obj)
        {

            case GameStates.StartLevel:
                StartCoroutine(StartShooting());
                break;
            case GameStates.Boss:
                UnblockShooting();
                break;
            case GameStates.BossStarts:
                BlockShooting();
                break;
            case GameStates.Win:
                BlockShooting();
                break;
            case GameStates.Lose:
                BlockShooting();
                break;

            default:
                break;
        }
    }


    private IEnumerator StartShooting()
    {
        while (!isBlocked)
        {
            yield return new WaitForSeconds(weaponCooldown);
            ShootProjectile();
            yield return null;
        }
    }

    private void ShootProjectile()
    {
        for (int i = 0; i < weaponMuzzles.Count; i++)
        {
            SpawnMuzzle(i);
            SpawnBullet(i);
        }
    }

    private void UpdateMuzzle()
    {
        //muzzleFlash = 
    }

    private void SpawnMuzzle(int i)
    {
        weaponMuzzles[i].PlayVFX();

        //var muzzle = muzzlePool.NextFree();
        //muzzle.gameObject.transform.position = weaponMuzzles[i].position;
    }

    private void SpawnBullet(int i)
    {
        //TODO: PLAY SOUND
        var bullet = bulletPool.NextFree();
        bullet.gameObject.transform.position = weaponMuzzles[i].transform.position;
        bullet.gameObject.transform.rotation = weaponMuzzles[i].transform.rotation;
    }
}
