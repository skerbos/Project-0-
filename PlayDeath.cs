using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayDeath : MonoBehaviour
{
    public int health = 3;
    public int damage = 1;
    public int CurrentHealth = 3;
    private AudioSource death;
    private GameObject Player;

    void Start()
    {
        death = GetComponent<AudioSource>();
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            CurrentHealth -= damage;
        }
        if (collision.gameObject.tag == "EnemyBullet")
        {
            CurrentHealth -= damage;
        }
        if (CurrentHealth <= 0f)
        {
            Die();
        }
    }
     void Die()
    {
        Destroy(gameObject, 0.1f);
        death.Play();
        SceneManager.LoadScene("Death");
    }
}