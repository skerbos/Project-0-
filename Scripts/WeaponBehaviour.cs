using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBehaviour : MonoBehaviour
{
    public GameObject player = GameObject.FindGameObjectWithTag("Player");
    public GameObject playerGun = GameObject.FindGameObjectWithTag("PlayerGun");
    public GameObject bullet;
    public string gunName;
    public float recoilForce;
    public float bulletSpeed;
    public float bulletSpread;
    public float bulletForce;
    public float rateOfFire;
    public int bulletsPerShot;
    public Material rifleMat;
    public Material sniperMat;
    public Material shotgunMat;

    public WeaponBehaviour()
    {
        
    }
    public virtual void Shoot()
    {
        if (player.GetComponent<Player>().positionLock == false)
        {
            player.GetComponent<Rigidbody2D>().AddForce(transform.up * recoilForce);
        }
        for (int i = 0; i < bulletsPerShot; i++)
        {
            Instantiate(bullet, playerGun.transform.position, playerGun.transform.rotation * Quaternion.Euler(0, 0, Random.Range(-bulletSpread, bulletSpread)));
        }
    }
}

public class Rifle : WeaponBehaviour
{
    public override void Shoot()
    {
        base.Shoot();
    }
}

