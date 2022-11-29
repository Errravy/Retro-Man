using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    Player player;
    [SerializeField] bool yAxis;
    float speed;
    void Start()
    {
        if (FindObjectOfType<Player>() != null)
        {
            player = FindObjectOfType<Player>();
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        if (player == null) { Destroy(gameObject); }
        speed = GameManager.speed;
        if (yAxis) { YAxis(); }
        else { XAxis(); }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            ChangeMode();
        }
    }
    void ChangeMode()
    {
        Transition.Instance.StartFade();

        var rnd = Random.Range(0, 2);
        if (player.mode == Mode.Normal)
        {
            if (rnd == 0) { player.mode = Mode.Fly; }
            else { player.mode = Mode.WallRun; }
        }
        else if (player.mode == Mode.Fly)
        {
            if (rnd == 0) { player.mode = Mode.Normal; }
            else { player.mode = Mode.WallRun; }
        }
        else if (player.mode == Mode.WallRun)
        {
            if (rnd == 0) { player.mode = Mode.Normal; }
            else { player.mode = Mode.Fly; }
        }
    }
    void XAxis()
    {
        transform.Translate(-speed * Time.deltaTime, 0, 0);
        Destroy(gameObject, 10);
    }
    void YAxis()
    {
        transform.Translate(0, -speed * Time.deltaTime, 0);
        Destroy(gameObject, 10);
    }
}
