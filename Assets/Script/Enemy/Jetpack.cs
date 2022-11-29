using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jetpack : MonoBehaviour
{
    [SerializeField] SoundFXSO sfx;
    Transform player;
    float speed;
    [SerializeField] float shootCD;
    [SerializeField] GameObject bullet;
    [SerializeField] Transform gun;
    [SerializeField] float bulletSpeed;
    [SerializeField] int ammo;
    bool attacking = false;

    float timeToShoot;
    void Awake()
    {
        if (FindObjectOfType<Player>() != null)
            player = FindObjectOfType<Player>().transform;

    }
    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<Player>().mode != Mode.Normal)
            Destroy(gameObject);
        if (!attacking)
        {
            speed = GameManager.speed;
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        }

        if (transform.position.x <= -12)
            Destroy(gameObject);

        if (player != null && transform.position.x - player.position.x <= 14.5f && ammo > 0)
        {
            attacking = true;
            speed = 0;
            if (timeToShoot < Time.time)
            {
                ammo--;
                GetComponent<Animator>().SetTrigger("shoot");
                timeToShoot = Time.time + shootCD;
            }
        }
        else if (attacking && ammo <= 0)
        {
            speed = GameManager.speed * 5;
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        }
    }
    public void Shoot()
    {
        GetComponent<AudioSource>().PlayOneShot(sfx.sound[0]);
        var bullet = Instantiate(this.bullet, gun.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(-bulletSpeed, 0);
        Destroy(bullet, 5);
    }
}
