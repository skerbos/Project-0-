using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageNumbers : MonoBehaviour
{
    private GameObject playerGun;
    public GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        playerGun = GameObject.FindGameObjectWithTag("PlayerGun");
        transform.GetComponent<Text>().text = "-" + playerGun.GetComponent<GunControl>().currentWeapon.bulletDamage.ToString();
        transform.SetParent(GameObject.Find("Canvas").transform);
        Destroy(gameObject, 0.3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
