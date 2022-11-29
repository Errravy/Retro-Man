using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootEnemy : MonoBehaviour
{
    [SerializeField] SoundFXSO sfx;
    Transform player;
    float speed;
    [SerializeField] float shootCD;
    [SerializeField] GameObject bullet;
    [SerializeField] Transform gun;
    [SerializeField] float bulletSpeed;

    float timeToShoot;
    void Awake()
    {
        if (FindObjectOfType<Player>() != null)
            player = FindObjectOfType<Player>().transform;

    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<Player>().mode != Mode.Normal)
            Destroy(gameObject);
        speed = GameManager.speed;
        transform.Translate(-speed * Time.deltaTime, 0, 0);

        if (transform.position.x <= -12)
            Destroy(gameObject);

        if (player != null && transform.position.x - player.position.x > 6)
        {
            if (timeToShoot < Time.time)
            {
                GetComponent<Animator>().SetTrigger("shoot");
                timeToShoot = Time.time + shootCD;
            }
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
