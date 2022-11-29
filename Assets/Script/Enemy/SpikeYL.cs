using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeYL : MonoBehaviour
{
    float speed;
    void Update()
    {
        var player = FindObjectOfType<Player>();
        if(player.mode != Mode.WallRun)
        Destroy(gameObject);
        speed = GameManager.speed;
        transform.Translate(-speed * Time.deltaTime,0,0);
        Destroy(gameObject,10);
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
