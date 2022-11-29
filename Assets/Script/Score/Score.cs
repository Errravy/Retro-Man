using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Score : MonoBehaviour
{
    [SerializeField] ScoreSO currScore;
    [SerializeField] ScoreSO highScore;
    [SerializeField] TextMeshProUGUI text;
    void Start()
    {
        if(currScore.score > highScore.score)
        {
            highScore.score = currScore.score;
            text.text = "New HighScore\n" + highScore.score.ToString();
            highScore.score = currScore.score;
        }
        else
        {
            text.text = "Score\n" + currScore.score.ToString() +"\n Highscore: " + highScore.score.ToString();
        }
    }
}
