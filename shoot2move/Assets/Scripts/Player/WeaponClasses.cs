using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponClasses : MonoBehaviour
{
    public abstract class GunType
    {
        public abstract void Shoot(GameObject player, GameObject playerGun, GameObject bullet);
    }

    public class BasicGun : GunType
    {
        public string gunName;
        public float recoilForce; //recoil force on player
        public float bulletDamage; //damage 1 bullet does
        public float bulletSpeed; // should link to maxSpeed in BulletMove script
        public float bulletSpread; // bullet spread in degrees
        public float bulletForce; // force bullet exerts on enemy
        public float rateOfFire; // bullets per second
        public int bulletsPerShot; // number of bullets on 1 shot
        public float playerMaxSpeed;
        public Color color; // color of gun

        public BasicGun(string gunName, float recoilForce, float bulletDamage, float bulletSpeed, float bulletSpread, float bulletForce, float rateOfFire, int bulletsPerShot, float playerMaxSpeed, Color color)
        {
            this.gunName = gunName;
            this.recoilForce = recoilForce;
            this.bulletDamage = bulletDamage;
            this.bulletSpeed = bulletSpeed;
            this.bulletSpread = bulletSpread;
            this.bulletForce = bulletForce;
            this.rateOfFire = rateOfFire;
            this.bulletsPerShot = bulletsPerShot;
            this.playerMaxSpeed = playerMaxSpeed;
            this.color = color;
        }

        public override void Shoot(GameObject player, GameObject playerGun, GameObject bullet)
        {
            if (player.GetComponent<PlayerControl>().positionLock == false)
            {
                player.GetComponent<Rigidbody2D>().AddForce(-playerGun.transform.right * recoilForce, ForceMode2D.Impulse);
            }
            for (int i = 0; i < bulletsPerShot; i++)
            {
                Instantiate(bullet, playerGun.transform.GetChild(0).position, playerGun.transform.rotation * Quaternion.Euler(0, 0, Random.Range(-bulletSpread, bulletSpread)));
            }
        }
    }
}
