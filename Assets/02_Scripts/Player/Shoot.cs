using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    [SerializeField] GameObject projectile;
    [SerializeField] float weaponCooldown;
    [SerializeField] List<Transform> weaponMuzzles;
    public bool isBlocked = false;

    //private void OnEnable()
    //{
    //    StartCoroutine("StartShooting");
    //}

    private void Start()
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
            Instantiate(projectile, weaponMuzzles[i].position, weaponMuzzles[i].rotation);
        }
    }
}
