using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] bool yAxis;
    [SerializeField] float tileSpeed;
    Player player;
    [SerializeField] Transform left;
    [SerializeField] Transform right;
    [SerializeField] Transform top;
    [SerializeField] Transform bottom;
    void Awake()
    {
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        tileSpeed = GameManager.speed;
        if(yAxis)
        {
            YAxis();
        }
        else
        {
            XAxis();
        }
        if(player.died)
        {
            tileSpeed = 0;
        }
    }
    void XAxis()
    {
        transform.Translate(-tileSpeed * Time.deltaTime,0,0);
        if(transform.position.x <= left.position.x)
        {
            transform.position = right.position;
        }
    }
    void YAxis()
    {
        transform.Translate(0,-tileSpeed * Time.deltaTime,0);
        if(transform.position.y <= bottom.position.y)
        {
            transform.position = top.position;
        }
    }
}
