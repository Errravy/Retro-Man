using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] SoundFXSO song;
    [SerializeField] GameObject gameOver;
    public static float speed;
    public static int score;
    int updateSpeed = 50;
    [Header("Tile")]
    [SerializeField] GameObject normalTile;
    [SerializeField] GameObject wallTile;
    [SerializeField] GameObject planeTile;

    [Header("Score")]
    [SerializeField] ScoreSO scoreSO;
    [SerializeField] TextMeshProUGUI text;
    float scorePlus;
    Player player;
    AudioSource sound;
    bool restart = false;
    void Awake()
    {
        speed = 5f;
    }
    void Start()
    {
        sound = GetComponent<AudioSource>();
        if (FindObjectOfType<Player>() != null)
            player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        ScoreAndSpeed();
        TileManager();
        SongManage();
    }
    void SongManage()
    {
        if (!sound.isPlaying)
        {
            sound.loop = true;
            sound.PlayOneShot(song.sound[1]);
        }
    }
    void CanRestart()
    {
        restart = true;
    }
    void ScoreAndSpeed()
    {
        if (restart && Input.GetKeyDown(KeyCode.Space))
        {
            score = 0;
            SceneManager.LoadScene(1);
        }
        if (player.died)
        {
            normalTile.SetActive(false);
            wallTile.SetActive(false);
            planeTile.SetActive(false);
            Destroy(text);
            speed = 0;
            gameOver.SetActive(true);
            Invoke("CanRestart", 0.3f);
        }
        if (scorePlus <= Time.time && !player.died)
        {
            score++;
            scoreSO.score = score;
            scorePlus = Time.time + 0.25f;
            text.text = "Score: " + scoreSO.score.ToString();
        }
        if (score == updateSpeed)
        {
            updateSpeed += 50;
            speed += 0.01f;
        }

    }
    void TileManager()
    {
        Mode mode = player.mode;
        if (mode == Mode.Normal)
        {
            normalTile.SetActive(true);
            wallTile.SetActive(false);
            planeTile.SetActive(false);
        }
        else if (mode == Mode.Fly)
        {
            normalTile.SetActive(false);
            wallTile.SetActive(false);
            planeTile.SetActive(true);
        }
        else if (mode == Mode.WallRun)
        {
            normalTile.SetActive(false);
            wallTile.SetActive(true);
            planeTile.SetActive(false);
        }
    }
}
