using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyClasses : MonoBehaviour
{
    public abstract class EnemyType
    {
        public abstract void Move(GameObject self, Rigidbody2D rb);
        public abstract void TrackPlayer(GameObject self, GameObject player);
        public abstract void Shoot(GameObject self, GameObject bullet);
        public abstract void LimitMaxSpeed(Rigidbody2D rb);
        public abstract void TakeDamage(GameObject playerGun);
        public abstract void Death(GameObject self, GameObject deathParticles, AudioSource deathSound, GameObject playerCamera);
    }

    public class BasicEnemy : EnemyType
    {
        public float health;
        public float moveForce;
        public float maxSpeed;
        public float rateOfFire;
        public float bulletDamage;
        public float bulletForce;
        public float nextFire;

        public BasicEnemy(float health, float moveForce, float maxSpeed, float rateOfFire, float bulletDamage, float bulletForce, float nextFire)
        {
            this.health = health;
            this.moveForce = moveForce;
            this.maxSpeed = maxSpeed;
            this.rateOfFire = rateOfFire;
            this.bulletDamage = bulletDamage;
            this.bulletForce = bulletForce;
            this.nextFire = nextFire;
        }

        public override void Move(GameObject self, Rigidbody2D rb)
        {
            rb.AddForce(self.transform.up * moveForce);
        }
        public override void TrackPlayer(GameObject self, GameObject player)
        {
            Vector2 playerDir = Camera.main.WorldToScreenPoint(player.transform.position) - Camera.main.WorldToScreenPoint(self.transform.position);
            float playerAngle = Mathf.Atan2(playerDir.y, playerDir.x) * Mathf.Rad2Deg;
            self.transform.rotation = Quaternion.Euler(0, 0, playerAngle - 90);
        }
        public override void Shoot(GameObject self, GameObject bullet)
        {
            if(Time.time > nextFire)
            {
                Instantiate(bullet, self.transform.position, self.transform.rotation);
                nextFire = Time.time + 1/rateOfFire;
            }
        }
        public override void LimitMaxSpeed(Rigidbody2D rb)
        {
            if (rb.velocity.magnitude > maxSpeed)
            {
                rb.velocity = rb.velocity.normalized * maxSpeed;
            }
        }

        public override void TakeDamage(GameObject playerGun)
        {
            health -= playerGun.GetComponent<GunControl>().currentWeapon.bulletDamage;
        }

        public override void Death(GameObject self, GameObject deathParticles, AudioSource deathSound, GameObject playerCamera)
        {
            if (health <= 0)
            {
                AudioSource.PlayClipAtPoint(deathSound.clip, self.transform.position);

                GameObject deathParticleClone = Instantiate(deathParticles);
                deathParticleClone.transform.position = self.transform.position;
                Destroy(deathParticleClone, 0.5f);

                playerCamera.GetComponent<CameraControl>().cameraShake(0.2f, 1f);

                Destroy(self.gameObject);
            }
        }

    }
}
