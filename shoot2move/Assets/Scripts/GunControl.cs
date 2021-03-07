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
        public float bulletForce;
        public float rateOfFire;

        public GunType(string gunName, float recoilForce, float bulletSpeed, float bulletForce, float rateOfFire)
        {
            this.gunName = gunName;
            this.recoilForce = recoilForce;
            this.bulletSpeed = bulletSpeed; // should link to maxSpeed in BulletMove script
            this.bulletForce = bulletForce; // force bullet exerts on enemy
            this.rateOfFire = rateOfFire; // bullets per second?
        }
    }


    private List<GunType> gunList;
    public GunType rifle = new GunType("rifle", 200f, 10f, 100f, 10f);
    public GunType sniper = new GunType("sniper", 1000f, 50f, 500f, 1f);
    public GunType currentWeapon;
    public GameObject player;
    public GameObject bullet;


    // Start is called before the first frame update
    void Start()
    {
        gunList = new List<GunType>()
                    {
                        rifle,
                        sniper
                    };

        currentWeapon = this.sniper;

        InvokeRepeating("Shoot", 0f, (1 / currentWeapon.rateOfFire));
    }

    // Update is called once per frame
    void Update()
    {
        
    }   

    void WeaponSelection()
    {

    }

    void Shoot()
    {
        if(Input.GetMouseButton(0))
        {
            player.GetComponent<Rigidbody2D>().AddForce(transform.up * currentWeapon.recoilForce);
            Instantiate(bullet, transform.position, transform.rotation);
        }
    }
}
