using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingComponent : MonoBehaviour
{
    public Action Shoot_Event;

    [SerializeField] GameObject projectile;
    [SerializeField] bool hasMuzzle = true;
    [SerializeField] GameObject muzzleFlash;
    ObjectPool bulletPool;
    ObjectPool muzzlePool;
    [SerializeField] float weaponCooldown;
    [SerializeField] List<Transform> weaponMuzzles;
    [SerializeField] int poolSize;
    public bool isBlocked = false;
    Transform poolParent;

    private void Awake()
    {
        poolParent = GameObject.Find(StringCollection.POOLPARENT).transform;
        bulletPool = new ObjectPool(projectile, poolSize, poolParent);
        if (hasMuzzle) muzzlePool = new ObjectPool(muzzleFlash, poolSize, poolParent);
    }

    private void OnEnable()
    {
        StartCoroutine(StartShooting());
    }


    private IEnumerator StartShooting()
    {
        while (!isBlocked)
        {
            yield return new WaitForSeconds(weaponCooldown);
            ShootProjectile();
            yield return null;
        }
        yield return null;
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
        var muzzle = muzzlePool.NextFree();
        muzzle.gameObject.transform.position = weaponMuzzles[i].position;
    }

    private void SpawnBullet(int i)
    {
        //TODO: PLAY SOUND
        var bullet = bulletPool.NextFree();
        bullet.gameObject.transform.position = weaponMuzzles[i].position;
        bullet.gameObject.transform.rotation = weaponMuzzles[i].rotation;
    }
}
