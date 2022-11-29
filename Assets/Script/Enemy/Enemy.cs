using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    float speed;
    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var player = FindObjectOfType<Player>();
        if (player.mode != Mode.Normal)
            Destroy(gameObject);
        speed = GameManager.speed;
        transform.Translate(-speed * Time.deltaTime, 0, 0);
        if (transform.position.x <= -12)
            Destroy(gameObject);
    }
    public void TurnOn()
    {
        GetComponent<BoxCollider2D>().enabled = true;
    }
    public void TurnOff()
    {
        GetComponent<BoxCollider2D>().enabled = false;
    }
}
