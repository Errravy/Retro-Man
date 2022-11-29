using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public enum Mode
{
    Normal,
    Fly,
    WallRun,
    Dead,
}
public class Player : MonoBehaviour
{
    [SerializeField] SoundFXSO sfx;
    [Header("Normal")]
    public Mode mode = Mode.Normal;
    [SerializeField] float jumpForce;

    [Header("Plane")]
    [SerializeField] Transform gun;
    [SerializeField] GameObject bullet;
    [SerializeField] float flyValue;
    [SerializeField] float shootDelay;
    [SerializeField] float bulletSpeed;

    [Header("Wall")]
    [SerializeField] float runSpeed;


    [Header("pos")]
    [SerializeField] Transform startPos;
    [SerializeField] Transform wallLeftPos;
    [SerializeField] Transform wallRightPos;
    [SerializeField] Transform planePos;

    AudioClip sound;
    AudioSource suara;
    public bool died = false;
    float canShoot;
    Rigidbody2D rb;
    PlayerControl pc;
    bool fly;
    bool grounded;
    bool wallpos = false;
    bool normal = false;
    bool flying = false;
    bool left = false;
    void Awake()
    {
        KeyBind();
    }
    void Start()
    {
        suara = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        WallMove();
        ModeControl();
        Grounded();
        AnimationControl();
    }
    void AnimationControl()
    {
        var anim = GetComponent<Animator>();
        anim.SetBool("Normal", mode == Mode.Normal);
        anim.SetBool("Plane", mode == Mode.Fly);
        anim.SetBool("Wall", mode == Mode.WallRun);
        anim.SetBool("Grounded", grounded);
        anim.SetFloat("Airing", rb.velocity.y);
    }
    void WallMove()
    {
        if (left && mode == Mode.WallRun)
        {
            transform.position = Vector3.MoveTowards(transform.position, wallRightPos.position, runSpeed * Time.deltaTime);
        }
        else if (!left && mode == Mode.WallRun)
        {
            transform.position = Vector3.MoveTowards(transform.position, wallLeftPos.position, runSpeed * Time.deltaTime);
        }
    }
    void Grounded()
    {
        var box = GetComponent<BoxCollider2D>();
        if (box.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }
    }
    void ModeControl()
    {
        if (mode == Mode.Normal)
        {
            var sprite = GetComponent<SpriteRenderer>();
            sprite.flipY = false;
            wallpos = false;
            flying = false;
            rb.gravityScale = 3;
            pc.Run.Enable();
            pc.Fly.Disable();
            pc.Wall.Disable();
            if (!normal)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
                transform.position = startPos.position;
                normal = true;
            }
        }
        else if (mode == Mode.Fly)
        {
            var sprite = GetComponent<SpriteRenderer>();
            sprite.flipY = false;
            wallpos = false;
            normal = false;
            rb.gravityScale = 3;
            pc.Fly.Enable();
            pc.Run.Disable();
            pc.Wall.Disable();
            if (!flying)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
                transform.position = planePos.position;
                flying = true;
            }
            if (canShoot <= Time.time)
            {
                var obj = Instantiate(bullet, gun.position, Quaternion.identity);
                obj.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletSpeed, 0);
                Destroy(obj, 5);
                canShoot = Time.time + shootDelay;
                suara.PlayOneShot(sfx.sound[2]);
            }
        }
        else if (mode == Mode.WallRun)
        {
            rb.velocity = Vector2.zero;
            rb.gravityScale = 0;
            var sprite = GetComponent<SpriteRenderer>();
            normal = false;
            flying = false;
            pc.Run.Disable();
            pc.Fly.Disable();
            pc.Wall.Enable();
            if (!wallpos)
            {
                sprite.flipY = true;
                transform.rotation = Quaternion.Euler(0, 0, 90);
                transform.position = wallLeftPos.position;
                wallpos = true;
            }
        }
    }
    void KeyBind()
    {
        pc = new PlayerControl();
        pc.Run.Enable();
        pc.Run.Jump.started += Jump;
        pc.Run.Jump.canceled += Jump;
        pc.Fly.Gravity.started += Fly;
        pc.Fly.Gravity.canceled += Fly;
        pc.Wall.Side.started += WallJump;
    }
    void Jump(InputAction.CallbackContext context)
    {
        if (context.started && grounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            suara.PlayOneShot(sfx.sound[1]);
        }
        if (context.canceled && rb.velocity.y >= 0 && mode == Mode.Normal)
        {
            rb.velocity = new Vector2(0, -3);
        }
    }
    void Fly(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            fly = true;
            StartCoroutine(FlyHold());
        }
        else if (context.canceled)
        {
            fly = false;
            StopCoroutine(FlyHold());
        }
    }
    void WallJump(InputAction.CallbackContext context)
    {
        var sprite = GetComponent<SpriteRenderer>();
        if (context.started && transform.position.x == wallLeftPos.position.x)
        {
            sprite.flipY = false;
            left = true;
            suara.PlayOneShot(sfx.sound[1]);
        }
        else if (context.started && transform.position.x == wallRightPos.position.x)
        {
            left = false;
            sprite.flipY = true;
            suara.PlayOneShot(sfx.sound[1]);
        }
    }
    IEnumerator FlyHold()
    {
        while (fly)
        {
            rb.velocity = new Vector2(rb.velocity.x, flyValue);
            yield return new WaitForSeconds(0);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            pc.Disable();
            mode = Mode.Dead;
            died = true;
            StartCoroutine(Died());
            // GameManager.score = 0;
            // SceneChanger.GameOver();
        }
    }
    IEnumerator Died()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }
    private void OnDisable()
    {
        pc.Disable();
    }
}
