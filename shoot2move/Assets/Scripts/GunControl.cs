using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunControl : MonoBehaviour
{
    public class GunType
    {
        public string gunName;
        public float recoilForce;
        public float bulletSpeed;
        public float bulletSpread;
        public float bulletForce;
        public float rateOfFire;
        public int bulletsPerShot;
        public Material mat;

        public GunType(string gunName, float recoilForce, float bulletSpeed, float bulletSpread, float bulletForce, float rateOfFire, int bulletsPerShot, Material mat)
        {
            this.gunName = gunName;
            this.recoilForce = recoilForce;
            this.bulletSpeed = bulletSpeed; // should link to maxSpeed in BulletMove script
            this.bulletSpread = bulletSpread; // bullet spread in degrees
            this.bulletForce = bulletForce; // force bullet exerts on enemy
            this.rateOfFire = rateOfFire; // bullets per second?
            this.bulletsPerShot = bulletsPerShot; // number of bullet on 1 shot
            this.mat = mat; // color of gun
        }

    }

    private List<GunType> gunList;
    public Material rifleMaterial;
    public Material sniperMaterial;
    public Material shotgunMaterial;
    public GunType rifle = new GunType("rifle", 100f, 20f, 3.5f, 100f, 10f, 1, null);
    public GunType sniper = new GunType("sniper", 1000f, 50f, 0f, 500f, 1f, 1, null);
    public GunType shotgun = new GunType("shotgun", 500f, 30f, 15f, 50f, 3f, 7, null);
    public GunType currentWeapon;
    public GameObject player;
    public GameObject bullet;


    // Start is called before the first frame update
    void Start()
    {
        gunList = new List<GunType>()
                    {
                        rifle,
                        sniper,
                        shotgun
                    };

        this.rifle.mat = rifleMaterial;
        this.sniper.mat = sniperMaterial;
        this.shotgun.mat = shotgunMaterial;

        currentWeapon = this.rifle;
        GetComponent<Renderer>().material = currentWeapon.mat;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            InvokeRepeating("Shoot", 0.001f, (1 / currentWeapon.rateOfFire));
        }
        if (Input.GetMouseButtonUp(0))
        {
            CancelInvoke();
        }

        WeaponSelection();
    }

    void WeaponSelection()
    {
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            currentWeapon = gunList[gunList.IndexOf(currentWeapon) + 1];
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            currentWeapon = gunList[gunList.IndexOf(currentWeapon) - 1];
        }
        GetComponent<Renderer>().material = currentWeapon.mat;
    }

    void Shoot()
    {
        if (player.GetComponent<PlayerControl>().positionLock == false)
        {
            player.GetComponent<Rigidbody2D>().AddForce(transform.up * currentWeapon.recoilForce);
        }
        for (int i = 0; i < currentWeapon.bulletsPerShot; i++)
        {
            Instantiate(bullet, transform.position, transform.rotation * Quaternion.Euler(0, 0, Random.Range(-currentWeapon.bulletSpread, currentWeapon.bulletSpread)));
        }
    }
}
