using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    float speed;
    bool death = false;
    private void Start() {
        StartCoroutine(Explode());
    }
    void Update()
    {
        var player = FindObjectOfType<Player>();
        if(player.mode != Mode.Fly)
        Destroy(gameObject);
        speed = GameManager.speed;
        if(death)
        {
            var x = 1 * Time.deltaTime;
            var y = 1 * Time.deltaTime;
            var z = 1 * Time.deltaTime;
            transform.localScale -= new Vector3(1,1,1) * Time.deltaTime;
            if(transform.localScale.x <= 0)
            Destroy(gameObject);
        }
         if(!death && transform.localScale.x <= 1)
        {
            transform.localScale += new Vector3(1,1,1) * Time.deltaTime;
        }   
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "bullet")
        {
            var rnd = Random.Range(0,101);
            if(rnd <= 50)
            {
                var obj = other.gameObject;
                obj.tag = "Enemy";
                obj.GetComponent<Rigidbody2D>().velocity = new Vector2(-20,0);
            }
            else
            {
                Destroy(other.gameObject);
            }
        }
    }
    IEnumerator Explode()
    {
        yield return new WaitForSeconds(5);
        death = true;  
    }
}
