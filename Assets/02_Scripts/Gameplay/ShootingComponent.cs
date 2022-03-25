using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingComponent : MonoBehaviour
{
    public Action Shoot_Event;

    [SerializeField] GameObject projectile;
    [SerializeField] GameObject muzzleFlash;
    ObjectPool bulletPool;
    ObjectPool muzzlePool;
    [SerializeField] float weaponCooldown;
    [SerializeField] List<Transform> weaponMuzzles;
    [SerializeField] int poolSize;
    public bool isBlocked = false;

    private void Awake()
    {
        bulletPool = new ObjectPool(projectile, poolSize, GameObject.Find("PoolParent").transform);
        //muzzleFlash = new ObjectPool()
    }

    private void OnEnable()
    {
        StartCoroutine("StartShooting");
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
            var bullet = bulletPool.NextFree();
            bullet.gameObject.transform.position = weaponMuzzles[i].position;
            bullet.gameObject.transform.rotation = weaponMuzzles[i].rotation;
        }
    }
}
