using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSwitch : MonoBehaviour
{
    Animator animator;
    Player player;
    void Start()
    {
        player = FindObjectOfType<Player>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player.mode == Mode.Normal)
        {
            animator.Play("Normal");
        }
        else if(player.mode == Mode.WallRun)
        {
            animator.Play("Wall");
        }
        else if(player.mode == Mode.Fly)
        {
            animator.Play("Plane");
        }
    }
}
