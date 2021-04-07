using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunControl : MonoBehaviour
{
    private List<WeaponClasses.BasicGun> gunList;
    private float nextFire;
    private GameObject player;
    private GameObject playerGun;
    private GameObject playerCamera;
    private AudioSource gunSound;
    public WeaponClasses.BasicGun rifle = new WeaponClasses.BasicGun("rifle", 5f, 5f, 25f, 3.5f, 170f, 15f, 1, 12f, Color.blue);
    public WeaponClasses.BasicGun sniper = new WeaponClasses.BasicGun("sniper", 1000f, 20f, 50f, 0f, 1000f, 1.5f, 1, 30f, Color.green);
    public WeaponClasses.BasicGun shotgun = new WeaponClasses.BasicGun("shotgun", 200f, 3f, 22f, 15f, 100f, 7f, 7, 11f, Color.red);
    public Color rifleMaterial;
    public Color sniperMaterial;
    public Color shotgunMaterial;
    public WeaponClasses.BasicGun currentWeapon;
    public GameObject bullet;

    


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerGun = GameObject.FindGameObjectWithTag("PlayerGun");
        playerCamera = GameObject.FindGameObjectWithTag("CameraHolder");
        gunSound = gameObject.GetComponent<AudioSource>();
        nextFire = Time.time;

        gunList = new List<WeaponClasses.BasicGun>()
                    {
                        rifle,
                        sniper,
                        shotgun
                    };

        this.rifle.color = rifleMaterial;
        this.sniper.color = sniperMaterial;
        this.shotgun.color = shotgunMaterial;

        currentWeapon = this.rifle;
        GetComponent<SpriteRenderer>().color = currentWeapon.color;

        SetPlayerMaxSpeed();
    }

    // Update is called once per frame
    void Update()
    {
        WeaponSelection();
    }

    void FixedUpdate()
    {
        Shoot();
    }
    void WeaponSelection()
    {
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            currentWeapon = gunList[gunList.IndexOf(currentWeapon) + 1];
            SetPlayerMaxSpeed();
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            currentWeapon = gunList[gunList.IndexOf(currentWeapon) - 1];
            SetPlayerMaxSpeed();
        }
        GetComponent<SpriteRenderer>().color = currentWeapon.color;
    }

    void Shoot()
    {
        if(Input.GetMouseButton(0) && Time.time > nextFire)
        {
            gunSound.Play();
            currentWeapon.Shoot(player, playerGun, bullet);
            nextFire = Time.time + (1 / currentWeapon.rateOfFire);
            playerCamera.GetComponent<CameraControl>().cameraShake(0.1f, 0.07f);
        }
    }
    void SetPlayerMaxSpeed()
    {
        player.GetComponent<PlayerControl>().maxSpeed = currentWeapon.playerMaxSpeed;
    }
}
