using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructiveShield : MonoBehaviour
{
    [SerializeField] float go;
    float timeToGo;
    Transform player;
    [SerializeField] Sprite[] sprite;
    int health = 4;
    int spriteIndex = 0;
    bool attacking = false;
    float speed;
    void Start()
    {
        player = FindObjectOfType<Player>().transform;
        timeToGo = go + Time.time;
    }

    // Update is called once per frame
    void Update()
    {
         if(player.GetComponent<Player>().mode != Mode.Fly)
        Destroy(gameObject);
        if(!attacking)
        {
            speed = GameManager.speed;
            transform.Translate(-speed * Time.deltaTime,0,0);
        }

        if(transform.position.x <= -12)
        Destroy(gameObject);

        if(player != null && transform.position.x - player.position.x   <= 14f && timeToGo > Time.time)
        {
            attacking = true;
            speed = 0;
        }
        if(health <= 0)
            {
                GetComponent<BoxCollider2D>().enabled = false;
                GetComponent<Animator>().enabled = true;
            }
        else if(timeToGo < Time.time)
        {
            attacking = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "bullet" && spriteIndex < 4)
        {
            Destroy(other.gameObject);
            spriteIndex++;
            health--;
            var sprit = GetComponent<SpriteRenderer>();
            sprit.sprite = sprite[spriteIndex]; 
        }
    }
    public void DestroyShield()
    {
        Destroy(gameObject);
    }
}
